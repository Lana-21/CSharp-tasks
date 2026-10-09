using System;
using System.Collections.Generic;
using System.Text;

namespace Home1
{
    internal static class Tasks
    {
        public static void Task1()
        {
            Console.Write("Enter a number from 1 to 100: ");
            string s = Console.ReadLine();
            if (!int.TryParse(s, out int number))
            {
                Console.WriteLine("Error");
                return;
            }
            if (number < 1 || number > 100)
            {
                Console.WriteLine("Error");
                return;
            }
            bool isFizz = (number % 3 == 0);
            bool isBuzz = (number % 5 == 0);
            switch (isFizz, isBuzz)
            {
                case (true, true):   
                    Console.WriteLine("Fizz Buzz");
                    break;
                case (true, false): 
                    Console.WriteLine("Fizz");
                    break;
                case (false, true):  
                    Console.WriteLine("Buzz");
                    break;
                default:             
                    Console.WriteLine(number);
                    break;
            }
        }

    public static void Task2()
        {
            Console.Write("Enter the value: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Error");
                return;
            }
            Console.Write("Enter the percentage: ");
            if (!double.TryParse(Console.ReadLine(), out double percent))
            {
                Console.WriteLine("Error");
                return;
            }
            double result = (value * percent) / 100.0;
            Console.WriteLine($"\nResult: {percent}% of {value} is {result}");
        }

    public static void Task3()
        {
            int number = 0;
            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"Enter digit {i} (0-9): ");
                string s = Console.ReadLine();
                if (!int.TryParse(s, out int digit))
                {
                    Console.WriteLine("Error");
                    return;
                }
                if (digit < 0 || digit > 9)
                {
                    Console.WriteLine("Error");
                    return;
                }
                number = number * 10 + digit;
            }
            Console.WriteLine($"\nResult: {number}");
        }

    public static void Task4()
        {
            Console.Write("Enter a 6-digit integer: \n");
            string s = Console.ReadLine();
            if (s.Length != 6)
            {
                Console.WriteLine("The input is not a 6-digit number!");
                return;
            }
            if (!int.TryParse(s, out int number))
            {
                Console.WriteLine("This is not a valid integer!");
                return;
            }
            Console.Write("Enter position 1 (1-6): ");
            int.TryParse(Console.ReadLine(), out int pos1);
            Console.Write("Enter position 2 (1-6): ");
            int.TryParse(Console.ReadLine(), out int pos2);
            if (pos1 < 1 || pos1 > 6 || pos2 < 1 || pos2 > 6)
            {
                Console.WriteLine("Error");
                return;
            }
            var chars = s.ToCharArray();
            char temp = chars[pos1 - 1];        
            chars[pos1 - 1] = chars[pos2 - 1];  
            chars[pos2 - 1] = temp;
            string result = new string(chars);
            Console.WriteLine($"\nResult: {result}");
        }

        public static void Task5()
        {
            Console.Write("Enter a date: ");
            string s = Console.ReadLine();
            if (!DateTime.TryParse(s, out DateTime date))
            {
                Console.WriteLine("Error");
                return;
            }
            string season;
            switch (date.Month)
            {
                case 12:
                case 1:
                case 2:
                    season = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Autumn";
                    break;
                default:
                    season = "";
                    break;
            }
            string dayOfWeek = date.DayOfWeek.ToString();
            Console.WriteLine($"\n{season} {dayOfWeek}");
        }

        public static void Task6()
        {
            Console.Write("Enter temperature value: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine("1.Fahrenheit to Celsius");
            Console.WriteLine("2.Celsius to Fahrenheit");
            Console.Write("Your choice (1 or 2):");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    double celsius = (value - 32) * 5.0 / 9.0;
                    Console.WriteLine($"\nResult: {value}°F = {celsius}°C");
                    break;
                case "2":
                    double fahrenheit = (value * 9.0 / 5.0) + 32;
                    Console.WriteLine($"\nResult: {value}°C = {fahrenheit}°F");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static void Task7()
        {
            Console.Write("Enter first number: ");
            if (!int.TryParse(Console.ReadLine(), out int start))
            {
                Console.WriteLine("Error");
                return;
            }
            Console.Write("Enter second number: ");
            if (!int.TryParse(Console.ReadLine(), out int end))
            {
                Console.WriteLine("Error");
                return;
            }
            if (start > end)
            {
                (start, end) = (end, start);
            }
            Console.WriteLine($"\nEven numbers in range {start}-{end}:");
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0) 
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
    }
}


