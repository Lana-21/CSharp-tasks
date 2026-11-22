using EXAM3.Data;
using EXAM3.Interfaces;
using EXAM3.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace EXAM3.Services
{
    public class QuizSession(DataStore store, IAuthManager auth, IFileManager files) : IQuizSession
    {
        public void StartQuiz()
        {
            if (auth.CurrentUser == null) return;
            try
            {
                Clear();
                WriteLine("SELECT QUIZ CATEGORY");
                var categories = store.Categories.Select(c => c.Category).ToList();
                if (!categories.Any())
                {
                    WriteLine("No categories available!");
                    ReadKey();
                    return;
                }
                for (int i = 0; i < categories.Count; i++)
                    WriteLine($"{i + 1}. {categories[i]}");
                WriteLine($"{categories.Count + 1}. Mixed Quiz (random questions)");
                Write("Your choice (or Enter to exit): ");
                if (!int.TryParse(ReadLine(), out int choice) || choice < 1 || choice > categories.Count + 1)
                    return;
                var random = new Random();
                string catName = choice <= categories.Count ? categories[choice - 1] : "Mixed";
                List<Question> questions = choice <= categories.Count
                    ? store.Categories.First(c => c.Category == catName).Questions.OrderBy(q => random.Next()).Take(5).ToList()
                    : store.Categories.SelectMany(c => c.Questions).OrderBy(q => random.Next()).Take(5).ToList();
                if (!questions.Any())
                {
                    WriteLine("No questions found in this category!");
                    ReadKey();
                    return;
                }
                Log.Information("User {User} started quiz in category: {Category}", auth.CurrentUser.Username, catName);
                RunQuiz(catName, questions);
            }
            catch (Exception ex)
            {
                WriteLine($"\nError starting quiz: {ex.Message}");
                Log.Error(ex, "Error starting quiz: {Message}", ex.Message);
                ReadKey();
            }
        }
        private void RunQuiz(string category, List<Question> questions)
        {
            int score = 0;
            foreach (var q in questions)
            {
                var correctAns = store.Answers.FirstOrDefault(a => a.QuestionId == q.Id);
                bool isMultipleChoice = (correctAns?.CorrectOptions.Count ?? 0) > 1;
                var userAns = AskQuestionAndGetValidInput(q, isMultipleChoice);
                if (correctAns != null)
                {
                    var normalizedUserAns = userAns.Select(x => x?.Trim().ToUpper() ?? "").OrderBy(x => x);
                    var normalizedCorrectAns = correctAns.CorrectOptions.Select(x => x?.Trim().ToUpper() ?? "").OrderBy(x => x);
                    bool isCorrect = normalizedUserAns.SequenceEqual(normalizedCorrectAns);
                    if (isCorrect)
                    {
                        WriteLine("\nCorrect answer!");
                        score++;
                    }
                    else WriteLine("\nIncorrect answer!");
                }
                WriteLine("\nPress any key for the next question");
                ReadKey();
            }
            var result = new QuizResult(auth.CurrentUser!.Username, category, score, DateTime.Now);
            files.AppendResult(result);
            var allCatResults = store.Results
                .Where(r => r.Category == category)
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.Date)
                .ToList();
            int rank = allCatResults.IndexOf(result) + 1;
            Clear();
            WriteLine("QUIZ COMPLETED");
            WriteLine($"Your score: {score} out of {questions.Count} correct answers.");
            WriteLine($"Your rank in {category} category: #{rank} out of {allCatResults.Count} players.");
            Log.Information("User {User} completed quiz {Category}. Score: {Score}/{Total}. Rank: {Rank}",
                result.Username, category, score, questions.Count, rank);
            WriteLine("\nPress any key to return to the menu");
            ReadKey();
        }
        private List<string> AskQuestionAndGetValidInput(Question q, bool isMultipleChoice)
        {
            while (true)
            {
                Clear();
                WriteLine($"Question: {q.Text}");
                foreach (var opt in q.Options)
                    WriteLine($"{opt.Key}: {opt.Value}");
                if (isMultipleChoice)
                    WriteLine("MultipleChoice");
                else
                    WriteLine("SingleChoice");
                Write("\nYour answer: ");
                string inputRaw = ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(inputRaw))
                {
                    WriteLine("\nError: Answer cannot be empty! Try again.");
                    ReadKey();
                    continue;
                }
                var userAns = inputRaw
                    .Split([' ', ','], StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim().ToUpper())
                    .Distinct()
                    .ToList();
                if (!userAns.All(ans => q.Options.ContainsKey(ans)))
                {
                    WriteLine("\nError: Invalid option letters");
                    ReadKey();
                    continue;
                }
                return userAns;
            }
        }
    }
}