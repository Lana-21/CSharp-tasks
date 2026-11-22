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
    public class QuizEditor(DataStore store, IFileManager files) : IQuizEditor
    {
        public void RunEditor()
        {
            try
            {
                Clear();
                WriteLine("QUIZ EDITOR UTILITY");
                string login = Prompt("Enter admin login: ");
                string pass = Prompt("Enter admin password: ");
                var admin = store.Users.FirstOrDefault(u => u.Username.Equals(login, StringComparison.OrdinalIgnoreCase) && u.Password == pass && u.IsAdmin);
                if (admin == null)
                {
                    Log.Error("Unauthorized editor access attempt by user: {Login}", login);
                    ShowMessage("\nAccess denied! Only the administrator can access the editor.");
                    return;
                }
                Log.Information("Administrator {User} logged into Quiz Editor.", admin.Username);
                while (true)
                {
                    Clear();
                    WriteLine($"QUIZ EDITOR (Admin: {admin.Username})\n1. View categories & questions\n2. Add question\n3. Delete question\n4. Exit");
                    switch (Prompt("Choose an option: "))
                    {
                        case "1":
                            ViewCategories();
                            break;
                        case "2":
                            AddQuestion();
                            break;
                        case "3":
                            DeleteQuestion();
                            break;
                        case "4": return;
                        default:
                            ShowMessage("\nInvalid choice! Please select from 1 to 4.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Editor error: {Message}", ex.Message);
                ShowMessage($"\nEditor error: {ex.Message}");
            }
        }
        private void ViewCategories()
        {
            Clear();
            WriteLine("CATEGORIES & QUESTIONS");
            if (!store.Categories.Any())
            {
                ShowMessage("No categories available.");
                return;
            }
            foreach (var g in store.Categories)
            {
                WriteLine($"\nCategory: {g.Category} (Total: {g.Questions.Count})");
                foreach (var q in g.Questions)
                {
                    var ans = store.Answers.FirstOrDefault(a => a.QuestionId == q.Id);
                    WriteLine($"  [{q.Id}] {q.Text} [Correct: {string.Join(", ", ans?.CorrectOptions ?? [])}]");
                }
            }
            ShowMessage("\nPress any key to continue");
        }
        private void AddQuestion()
        {
            Clear();
            WriteLine("ADD NEW QUESTION\nAvailable categories: " + string.Join(", ", store.Categories.Select(c => c.Category)));
            string cat = Prompt("Enter category name: ");
            if (string.IsNullOrWhiteSpace(cat))
            {
                ShowMessage("category cannot be empty!");
                return;
            }
            string text = Prompt("Enter question text: ");
            if (string.IsNullOrWhiteSpace(text))
            {
                ShowMessage("Question text cannot be empty!");
                return;
            }
            var options = ReadOptions();
            if (options.Count < 2)
            {
                ShowMessage("At least two options required!");
                return;
            }
            List<string> correct;
            while (true)
            {
                correct = ReadCorrectAnswers().Where(options.ContainsKey).Distinct().ToList();
                if (correct.Any())
                {
                    break;
                }
                WriteLine($"At least one valid option letter required! Available: {string.Join(", ", options.Keys)}");
            }
            SaveNewQuestion(cat, text, options, correct);
            Log.Information("Admin added question to '{Category}'.", cat);
            ShowMessage("\nQuestion successfully added!");
        }
        private void DeleteQuestion()
        {
            while (true)
            {
                Clear();
                WriteLine("DELETE QUESTION");
                if (!PrintQuestions()) return;
                string input = Prompt("\nEnter ID to delete (0 to cancel): ");
                if (!int.TryParse(input, out int id) || id == 0)
                {
                    return;
                }
                var category = store.Categories.FirstOrDefault(c => c.Questions.Any(q => q.Id == id));
                if (category == null)
                {
                    ShowMessage("Question not found! Press any key to try again.");
                    continue;
                }
                category.Questions.RemoveAll(q => q.Id == id);
                store.Answers.RemoveAll(a => a.QuestionId == id);
                if (category.Questions.Count == 0)
                    store.Categories.Remove(category);
                files.SaveQuestionsAndAnswers();
                Log.Information("Admin deleted question ID {Id}.", id);
                ShowMessage("\nQuestion deleted successfully!");
                break;
            }
        }
        private bool PrintQuestions()
        {
            var all = store.Categories.SelectMany(c => c.Questions).ToList();
            if (!all.Any())
            {
                ShowMessage("No questions available.");
                return false;
            }
            all.ForEach(q => WriteLine($"[{q.Id}] {q.Text}"));
            return true;
        }
        private Dictionary<string, string> ReadOptions()
        {
            var opts = new Dictionary<string, string>();
            WriteLine("Enter options ('done' to finish):");
            for (char k = 'A'; ; k++)
            {
                string val = Prompt($"Option {k}: ");
                if (val.Equals("done", StringComparison.OrdinalIgnoreCase)) break;
                if (string.IsNullOrWhiteSpace(val))
                {
                    WriteLine("Option cannot be empty!");
                    k--;
                    continue;
                }
                opts[k.ToString()] = val;
            }
            return opts;
        }
        private List<string> ReadCorrectAnswers() =>
            Prompt("Enter correct letters (space or comma separated): ")
                .Split([' ', ','], StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().ToUpper())
                .ToList();
        private void SaveNewQuestion(string category, string text, Dictionary<string, string> options, List<string> correct)
        {
            var group = store.Categories.FirstOrDefault(c => c.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (group == null) store.Categories.Add(group = new CategoryGroup { Category = category });
            int id = store.Categories.SelectMany(c => c.Questions).Select(q => q.Id).DefaultIfEmpty(0).Max() + 1;
            group.Questions.Add(new Question { Id = id, Text = text, Options = options, CorrectOptions = correct });
            store.Answers.Add(new AnswerModel { QuestionId = id, CorrectOptions = correct });
            files.SaveQuestionsAndAnswers();
        }
        private static string Prompt(string text)
        {
            Write(text);
            return (ReadLine() ?? "").Trim();
        }
        private static void ShowMessage(string text)
        {
            WriteLine(text);
            ReadKey();
        }
    }
}