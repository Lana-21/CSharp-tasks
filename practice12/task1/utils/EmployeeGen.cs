using ConsoleApp12List.models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConsoleApp4List.utils
{
    public static class EmployeeGen
    {
        private static string[] firstNames = { "Anna", "Mark", "Vasya", "Oleksa", "Igor" };
        private static string[] lastNames = { "Kravchenko", "Kucherenko", "Sobol", "Minyaylo", "Shevchenko" };
        private static string[] positions = { "Position1", "Position2", "Position3" };
        private const int Min = 35875;
        private const int Max = 100000;
        private static string[] emails = { "Email1", "Email12", "Email13", "Email14" };
        static Random rnd = new();
        public static string GenFirstName()
        {
            return firstNames[rnd.Next(0, firstNames.Length)];
        }
        public static string GenLastName()
        {
            return lastNames[rnd.Next(0, lastNames.Length)];
        }
        public static string GenPosition()
        {
            return positions[rnd.Next(0, positions.Length)];
        }
        public static int GenWages()
        {
            return rnd.Next(Min, Max);
        }
        public static string GenEmail()
        {
            return emails[rnd.Next(0, emails.Length)] + rnd.Next() % 100 + "@gmail.com";
        }
        public static Employee GenEmployee()
        {
            return new Employee(
                 GenFirstName(),
                 GenLastName(),
                 GenPosition(),
                 GenWages(),
                 GenEmail()
                 ); 
        }
        public static List<Employee> GenEmployees(int n)
        {
            List<Employee> list = new();
            for (int i = 0; i < n; ++i)
            {
                list.Add(GenEmployee());
            }
            return list;
        }
    }
}
