using EXAM3.Data;
using EXAM3.Interfaces;
using Serilog;
using System;
using System.Linq;
using static System.Console;

namespace EXAM3.Services
{
    public class QuizStatistics(DataStore store, IAuthManager auth) : IQuizStatistics
    {
        public void ShowMyResults()
        {
            if (auth.CurrentUser == null) return;
            try
            {
                Clear();
                WriteLine("MY PAST RESULTS");
                var my = store.Results.Where(r => r.Username == auth.CurrentUser.Username).ToList();
                if (!my.Any()) WriteLine("You haven't taken any quizzes yet");
                else
                {
                    foreach (var r in my)
                        WriteLine($"Category: {r.Category}  Score: {r.Score}  Date: {r.Date:yyyy-MM-dd HH:mm}");
                }
            }
            catch (Exception ex)
            {
                WriteLine($"\nError loading results: {ex.Message}");
                Log.Error(ex, "Error loading user results: {Message}", ex.Message);
            }
            WriteLine("\nPress any key to continue");
            ReadKey();
        }
        public void ShowTop3ForCategory()
        {
            if (auth.CurrentUser == null) return;
            try
            {
                while (true)
                {
                    Clear();
                    WriteLine("SELECT CATEGORY FOR TOP 3");
                    var cats = store.Categories.Select(c => c.Category).ToList();
                    if (!cats.Any())
                    {
                        WriteLine("No categories available");
                        ReadKey();
                        return;
                    }
                    for (int i = 0; i < cats.Count; i++)
                        WriteLine($"{i + 1}. {cats[i]}");
                    WriteLine("0. Exit");
                    Write("Your choice (0 to exit): ");
                    string input = (ReadLine() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(input) || input == "0")
                    {
                        return;
                    }
                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= cats.Count)
                    {
                        string cat = cats[choice - 1];
                        var top = store.Results
                            .Where(r => r.Category == cat)
                            .OrderByDescending(r => r.Score)
                            .ThenBy(r => r.Date)
                            .Take(3)
                            .ToList();
                        Clear();
                        WriteLine($"TOP 3 RESULTS FOR {cat}");
                        if (!top.Any())
                            WriteLine("No results for this category.");
                        else
                        {
                            for (int i = 0; i < top.Count; i++)
                                WriteLine($"{i + 1}. Player: {top[i].Username} Score: {top[i].Score}  Date: {top[i].Date:yyyy-MM-dd HH:mm}");
                        }
                        WriteLine("\nPress any key to continue");
                        ReadKey();
                        break;
                    }
                    else
                    {
                        WriteLine("\nInvalid choice");
                        ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine($"\nError loading Top 3: {ex.Message}");
                Log.Error(ex, "Error loading Top 3: {Message}", ex.Message);
                ReadKey();
            }
        }
    }
}