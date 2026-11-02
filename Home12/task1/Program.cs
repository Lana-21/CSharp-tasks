using static System.Console;
using Home12List.utils;
using Home12List.services;

namespace Home12List
{
    internal class Program
    {
        //задання1
        static void Main(string[] args)
        {
            var initialData = AuthGen.GenEmployees(4);
            ServiceEmployeeAuth authService = new(initialData);
            int choice = 0;
            string menu = """
        0. Exit
        1. Add login and password
        2. Remove employee login
        3. Update employee password
        4. Get password by login
        5. Show all records
        """;
            do
            {
                Clear();
                WriteLine(menu);
                Write("\nYour choice: ");
                if (!int.TryParse(ReadLine(), out choice))
                {
                    WriteLine("\nInvalid input format");
                    ReadKey();
                    continue;
                }
                if (choice == 0) break;
                switch (choice)
                {
                    case 1:
                        string login = AuthGen.GenLogin();
                        string password = AuthGen.GenPassword();
                        WriteLine($"\nGenerated -> Login: {login} Password: {password}");
                        if (authService.AddEmployee(login, password))
                            WriteLine("\nEmployee successfully added");
                        else WriteLine("\nError");
                        break;
                    case 2:
                        Write("Enter login to remove: ");
                        string delLogin = ReadLine();
                        if (authService.RemoveEmployee(delLogin))
                            WriteLine("\nLogin successfully removed");
                        else WriteLine("\nError");
                        break;
                    case 3:
                        Write("Enter login to update: ");
                        string updLogin = ReadLine();
                        Write("Enter new password: ");
                        string newPass = ReadLine();
                        if (authService.UpdatePassword(updLogin, newPass))
                            WriteLine("\nPassword successfully updated");
                        else WriteLine("\nError");
                        break;
                    case 4:
                        Write("Enter login to search: ");
                        string searchLogin = ReadLine();
                        string pass = authService.GetPassword(searchLogin);
                        if (pass != null)
                            WriteLine($"\nPassword for {searchLogin}: {pass}");
                        else WriteLine("\nError");
                        break;
                    case 5:
                        WriteLine("\nList of all employees:");
                        var all = authService.GetAllEmployees();
                        if (all.Count == 0) WriteLine("Dictionary is empty.");
                        else
                        {
                            int i = 0;
                            foreach (var item in all)
                            {
                                WriteLine($"{++i}. Login: {item.Key} Password: {item.Value}");
                            }
                        }
                        break;
                    default:
                        break;
                }
                ReadKey();
            } while (true);
        }
    }
}
