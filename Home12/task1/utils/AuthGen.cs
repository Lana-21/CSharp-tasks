using System;
using System.Collections.Generic;
using System.Text;

namespace Home12List.utils
{
    public static class AuthGen
    {
        private static string[] roles = { "admin", "manager", "developer", "hr", "support", "analyst" };
        private static Random rnd = new();
        public static string GenLogin()
        {
            string role = roles[rnd.Next(roles.Length)];
            int number = rnd.Next(10, 100);
            return $"{role}_{number}";
        }
        public static string GenPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] pass = new char[7];
            for (int i = 0; i < pass.Length; i++)
            {
                pass[i] = chars[rnd.Next(chars.Length)];
            }
            return new string(pass);
        }
        public static Dictionary<string, string> GenEmployees(int n)
        {
            Dictionary<string, string> dict = new();
            while (dict.Count < n)
            {
                string login = GenLogin();
                string password = GenPassword();
                if (!dict.ContainsKey(login)) dict.Add(login, password);
            }
            return dict;
        }
    }
}
