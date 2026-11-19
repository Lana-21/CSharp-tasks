using Practice18.DTO;
using Practice18.Models;
using Practice18.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Practice18.Utilities
{
    public static class MenuUtility
    {
        public static void ShowMainMenu(List<User> usersList)
        {
            while (true)
            {
                Clear();
                WriteLine("USER MANAGEMENT SYSTEM");
                WriteLine("1. Register a new user");
                WriteLine("2. Authorization (Login)");
                WriteLine("3. Show all loaded users");
                WriteLine("4. Save data");    
                WriteLine("5. Exit");          
                Write("Choose an option (1-5): ");
                string? choice = ReadLine();
                WriteLine();
                switch (choice)
                {
                    case "1":
                        RegisterUser(usersList);
                        break;
                    case "2":
                        AuthorizeUser(FileService.LoadUsers());
                        break;
                    case "3":
                        ShowAllUsers();
                        break;
                    case "4":
                        FileService.SaveUsers(usersList);
                        WriteLine("Data successfully saved");
                        break;
                    case "5":
                        WriteLine("Exiting program");
                        return;
                    default:
                        WriteLine("ERROR: Invalid choice");
                        break;
                }
                WriteLine("\nPress any key to continue");
                ReadKey();
            }
        }
        private static void RegisterUser(List<User> usersList)
        {
            WriteLine("NEW USER REGISTRATION");
            User newUser = new User();
            Write("Enter first name: ");
            newUser.FirstName = ReadLine() ?? "";
            Write("Enter last name: ");
            newUser.LastName = ReadLine() ?? "";
            Write("Enter birth date (YYYY-MM-DD): ");
            if (DateOnly.TryParse(ReadLine(), out DateOnly bDate))
            {
                newUser.BirthDate = bDate;
            }
            else newUser.BirthDate = new DateOnly(2000, 10, 10);
            Write("Enter email: ");
            newUser.Email = ReadLine() ?? "";
            Write("Enter login: ");
            newUser.Login = ReadLine() ?? "";
            Write("Enter password: ");
            string pass1 = ReadLine() ?? "";
            Write("Confirm password: ");
            string pass2 = ReadLine() ?? "";
            if (pass1 == pass2 && !string.IsNullOrEmpty(pass1))
            {
                newUser.Password = pass1;
                usersList.Add(newUser);
                FileService.SaveUsers(usersList);
                WriteLine("\nSUCCESS");
                Serilog.Log.Information("User {Login} successfully registered", newUser.Login);
            }
            else
            {
                WriteLine("\nERROR");
                Serilog.Log.Information("Failed registration for {Login}", newUser.Login);
            }
        }
        private static void AuthorizeUser(List<User>? usersList)
        {
            WriteLine("SYSTEM AUTHORIZATION");
            if (usersList == null || usersList.Count == 0)
            {
                WriteLine("No registered users");
                return;
            }
            Write("Enter login: ");
            string inputLogin = ReadLine() ?? "";
            Write("Enter password: ");
            string inputPassword = ReadLine() ?? "";
            LoginDto loginAttempt = new LoginDto(inputLogin, inputPassword);
            Serilog.Log.Information("Authorization attempt for: {Login}", loginAttempt.Login);
            User? authUser = usersList.FirstOrDefault(u => u.Login == loginAttempt.Login && u.Password == loginAttempt.Password);
            if (authUser != null)
            {
                WriteLine($"\nSUCCESS Authorized as {authUser.FirstName}");
                Serilog.Log.Information("User {Login} successfully authorized in the system", loginAttempt.Login);
                ShowRandomQuote(authUser);
            }
            else
            {
                WriteLine("\nERROR");
                Serilog.Log.Information("Failed authorization attempt for: {Login}", loginAttempt.Login);
            }
        }
        private static void ShowRandomQuote(User authUser)
        {
            WriteLine();
            WriteLine($"WELCOME TO THE SYSTEM, {authUser.FirstName}");
            WriteLine();
            List<string> quotes = new List<string>
            {
                "«Code is like humor. When you have to explain it, it’s bad.»",
                "«An error is just an opportunity to write a test for its fix.»",
                "«The best way to predict the future is to invent it.»",
                "«Simplicity and clean code are the keys to a successful project.»",
                "«Live as if you were to die tomorrow. Learn as if you were to live forever.»"
            };
            Random random = new Random();
            string selectedQuote = quotes[random.Next(quotes.Count)];
            WriteLine("\n Quote for you:");
            WriteLine(selectedQuote);
            WriteLine();
        }
        private static void ShowAllUsers()
        {
            WriteLine("ALL REGISTERED USERS");
            List<User>? usersList = FileService.LoadUsers();
            if (usersList == null || usersList.Count == 0)
            {
                WriteLine("The user list is empty.");
                return;
            }
            foreach (var u in usersList)
            {
                WriteLine(u);
            }
        }
    }
}
