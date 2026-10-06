using System;
using System.Collections.Generic;
using System.Text;

namespace Practice1
{
    internal static class Tasks
    {
        public static void Task1()
        {
            Console.WriteLine("It's easy to win forgiveness for being wrong;");
            Console.WriteLine("being right is what gets you into real trouble.");
            Console.WriteLine("Bjarne Stroustrup\n");
        }
        public static void Task2()
        {
            const int N = 5;
            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0;
            double product = 1;
            for (int i = 1; i <= N; i++)
            {
                Console.Write($"Enter number {i}: ");
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    sum += number;
                    product *= number;
                    if (number < min) min = number;
                    if (number > max) max = number;
                }
                else
                {
                    Console.WriteLine("Invalid number format, please try again.");
                    i--; 
                }
            }
            Console.WriteLine("\nResults:");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}\n");
        }
        public static void Task3()
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
            var arrChar = s.ToCharArray();
            Array.Reverse(arrChar);
            s = new string(arrChar);
            Console.WriteLine($"Reversed number: {s}\n");
        }
    }
}
