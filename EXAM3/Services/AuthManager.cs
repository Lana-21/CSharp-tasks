using EXAM3.Data;
using EXAM3.Interfaces;
using EXAM3.Models;
using Serilog;
using System;
using System.Linq;
using static System.Console;

namespace EXAM3.Services
{
    public class AuthManager(DataStore store, IFileManager files) : IAuthManager
    {
        public User? CurrentUser { get; set; }
        public void Register()
        {
            try
            {
                Clear();
                WriteLine("NEW USER REGISTRATION");
                if (!TryReadLogin(out string login) ||
                    !TryReadPassword(login, out string password) ||
                    !TryReadBirthDate(login, out DateTime birthDate))
                {
                    Pause();
                    return;
                }
                CompleteRegistration(login, password, birthDate);
                Pause();
                Login();
                return;
            }
            catch (Exception ex)
            {
                WriteLine($"\nError during registration: {ex.Message}");
                Log.Error(ex, "Exception during registration: {Message}", ex.Message);
            }
            Pause();
        }
        private bool TryReadLogin(out string login)
        {
            login = "";
            Write("Enter login: ");
            string input = ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("\nError: Username cannot be empty!");
                Log.Information("Failed registration attempt: empty login.");
                return false;
            }
            if (store.Users.Any(u => u.Username.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                WriteLine("\nError: User with this username already exists!");
                Log.Information("Failed registration attempt: user {Login} already exists.", input);
                return false;
            }
            login = input;
            return true;
        }
        private bool TryReadPassword(string login, out string password)
        {
            password = "";
            Write("Enter password: ");
            string pass1 = ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(pass1))
            {
                WriteLine("\nERROR: Password cannot be empty!");
                Log.Information("Failed registration for {Login}: empty password", login);
                return false;
            }
            Write("Confirm password: ");
            string pass2 = ReadLine() ?? "";
            if (pass1 != pass2)
            {
                WriteLine("\nERROR: Passwords do not match!");
                Log.Information("Failed registration for {Login}: password mismatch", login);
                return false;
            }
            password = pass1;
            return true;
        }
        private bool TryReadBirthDate(string login, out DateTime birthDate)
        {
            birthDate = default;
            Write("Enter birth date (YYYY-MM-DD): ");
            if (!DateTime.TryParse(ReadLine(), out birthDate))
            {
                WriteLine("\nERROR: Invalid date format! Registration failed.");
                Log.Information("Failed registration for {Login}: invalid birth date format", login);
                return false;
            }
            return true;
        }
        private void CompleteRegistration(string login, string password, DateTime birthDate)
        {
            var role = store.Users.Count == 0 ? UserRole.Admin : UserRole.Player;
            var newUser = new User(login, password, birthDate, role);
            store.Users.Add(newUser);
            files.SaveUsers();  
            WriteLine("\nSUCCESS");
            WriteLine(newUser.Role == UserRole.Admin
                ? "You are registered as the Administrator."
                : "You can now log in.");
            Log.Information("User {Login} successfully registered (Role: {Role})", login, newUser.Role);
        }
        public void Login()
        {
            try
            {
                Clear();
                WriteLine("SYSTEM AUTHORIZATION");
                if (!store.Users.Any())
                {
                    WriteLine("\nNo registered users in the system.");
                    Pause(null);
                    return;
                }
                Write("Enter login: ");
                string inputLogin = (ReadLine() ?? "").Trim();
                Write("Enter password: ");
                string inputPassword = ReadLine() ?? "";
                var loginAttempt = new LoginDto(inputLogin, inputPassword);
                Log.Information("Authorization attempt for: {Login}", loginAttempt.Login);
                CurrentUser = store.Users.FirstOrDefault(u =>
                    u.Username.Equals(loginAttempt.Login, StringComparison.OrdinalIgnoreCase) &&
                    u.Password == loginAttempt.Password);
                if (CurrentUser != null)
                {
                    WriteLine($"\nSUCCESS! Authorized as {CurrentUser.Username}");
                    if (CurrentUser.Role == UserRole.Admin)
                    {
                        WriteLine("Welcome, Administrator!");
                    }
                    Log.Information("User {Login} successfully authorized", loginAttempt.Login);
                }
                else
                {
                    WriteLine("\nERROR: Invalid username or password!");
                    Log.Information("Failed authorization attempt for: {Login}", loginAttempt.Login);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"\nError during login: {ex.Message}");
                Log.Error(ex, "Exception during login: {Message}", ex.Message);
            }
            Pause(null);
        }
        public void ChangeSettings()
        {
            if (CurrentUser == null) return;
            try
            {
                Clear();
                WriteLine("CHANGE SETTINGS");
                WriteLine($"Current user: {CurrentUser.Username}");
                WriteLine($"Current birth date: {CurrentUser.BirthDate:yyyy-MM-dd}\n");
                if (!VerifyCurrentPassword())
                    return;
                WriteLine("\nIdentity verified!\n");
                bool passwordChanged = TryUpdatePassword();
                bool birthDateChanged = TryUpdateBirthDate();
                bool updated = passwordChanged || birthDateChanged;
                SaveAndShow(updated);
            }
            catch (Exception ex)
            {
                WriteLine($"\nError changing settings: {ex.Message}");
                Log.Error(ex, "Error changing settings: {Message}", ex.Message);
            }
            Pause("\nPress any key to continue");
        }
        private bool VerifyCurrentPassword()
        {
            while (true)
            {
                Write("Enter your CURRENT password to continue (0 to go back): ");
                string currentPass = (ReadLine() ?? "").Trim();
                if (currentPass == "0")
                {
                    return false;
                }
                if (currentPass == CurrentUser!.Password)
                {
                    return true;
                }
                WriteLine("\nERROR: Incorrect current password! Try again or enter 0 to cancel.\n");
                Log.Information("Failed settings change attempt for {Login}: wrong current password.", CurrentUser.Username);
            }
        }
        private bool TryUpdatePassword()
        {
            Write("Enter NEW password (leave blank to skip): ");
            string newPassword = ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(newPassword))
                return false;
            Write("Confirm NEW password: ");
            string confirmPassword = ReadLine() ?? "";
            if (newPassword == confirmPassword)
            {
                CurrentUser!.Password = newPassword;
                return true;
            }
            WriteLine("\nERROR: Passwords do not match. Password was not changed.");
            return false;
        }
        private bool TryUpdateBirthDate()
        {
            Write("Enter NEW birth date (YYYY-MM-DD, leave blank to skip): ");
            string dateInput = ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(dateInput))
                return false;
            if (DateTime.TryParse(dateInput, out var newDate))
            {
                CurrentUser!.BirthDate = newDate;
                return true;
            }
            WriteLine("\nERROR: Invalid date format!");
            return false;
        }
        private void SaveAndShow(bool updated)
        {
            if (updated)
            {
                files.SaveUsers();
                WriteLine("\nSETTINGS SUCCESSFULLY UPDATED!");
                WriteLine($"Login: {CurrentUser!.Username}");
                WriteLine($"Birth Date: {CurrentUser.BirthDate:yyyy-MM-dd}");
                WriteLine($"Role: {CurrentUser.Role}");
                Log.Information("Settings successfully updated for {Login}", CurrentUser.Username);
            }
            else
            {
                WriteLine("\nNo changes were saved.");
                Log.Information("Settings update for {Login}: No changes were saved.", CurrentUser!.Username);
            }
        }
        private static void Pause(string? message = "Press any key to continue")
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteLine(message);
            }
            ReadKey();
        }
    }
}