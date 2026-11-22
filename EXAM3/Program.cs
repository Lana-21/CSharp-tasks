using EXAM3.Data;
using EXAM3.Interfaces;
using EXAM3.Models;
using EXAM3.Services;
using Serilog;
using System;
using System.IO;
using static System.Console;

namespace EXAM3
{
    internal class Program
    {
        static void Main()
        {
            Directory.CreateDirectory("logs");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/quiz_log.json", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Application started in EXAM3.");
            var store = new DataStore();
            IFileManager files = new FileManager(store);
            IAuthManager auth = new AuthManager(store, files);
            IQuizSession quiz = new QuizSession(store, auth, files);
            IQuizStatistics stats = new QuizStatistics(store, auth);
            IQuizEditor editor = new QuizEditor(store, files);
            files.LoadData();
            while (true)
            {
                try
                {
                    Clear();
                    if (auth.CurrentUser == null)
                    {
                        WriteLine("QUIZ");
                        WriteLine("1. Log in");
                        WriteLine("2. Register");
                        WriteLine("3. Quiz Editor Utility (Admin login required)");
                        WriteLine("4. Exit application");
                        Write("Choose an option: ");
                        switch (ReadLine()?.Trim())
                        {
                            case "1":
                                auth.Login();
                                break;
                            case "2":
                                auth.Register();
                                break;
                            case "3":
                                editor.RunEditor();
                                break;
                            case "4":
                                WriteLine("\nThank you for using Quiz Application. Goodbye!");
                                Log.Information("User exited application.");
                                return;
                            default:
                                WriteLine("\nInvalid choice! Please enter a number from 1 to 4.");
                                ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        string roleBadge = auth.CurrentUser.Role == UserRole.Admin ? " [ADMIN]" : "";
                        WriteLine($"MAIN MENU (User: {auth.CurrentUser.Username}{roleBadge})");
                        WriteLine("1. Start a new quiz");
                        WriteLine("2. View my past quiz results");
                        WriteLine("3. View Top 3 results for a specific category");
                        WriteLine("4. Change settings (password and birth date)");
                        WriteLine("5. Log out");
                        WriteLine("6. Exit application");
                        Write("Choose an option: ");
                        switch (ReadLine()?.Trim())
                        {
                            case "1":
                                quiz.StartQuiz();
                                break;
                            case "2":
                                stats.ShowMyResults();
                                break;
                            case "3":
                                stats.ShowTop3ForCategory();
                                break;
                            case "4":
                                auth.ChangeSettings();
                                break;
                            case "5":
                                Log.Information("User {User} logged out.", auth.CurrentUser.Username);
                                auth.CurrentUser = null;
                                break;
                            case "6":
                                WriteLine("\nThank you for using Quiz Application. Goodbye!");
                                Log.Information("User exited application from main menu.");
                                return;
                            default:
                                WriteLine("\nInvalid choice! Please enter a number from 1 to 6.");
                                ReadKey();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error: {Message}", ex.Message);
                    WriteLine($"\nError: {ex.Message}");
                    ReadKey();
                }
            }
        }
    }
}
