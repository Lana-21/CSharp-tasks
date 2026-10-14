using System;
using System.Collections.Generic;
using System.Text;

namespace Home3
{
    internal class Tasks
    {
        public static void Task1()
        {
            int side = 5;
            char symbol = '*';
            Console.WriteLine($"Square length {side} symbol '{symbol}':\n");
            CreateSquare(side, symbol);
        }
        private static void CreateSquare(int side, char symbol)
        {
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Task2()
        {
            int number1 = 1551;
            int number2 = 3443;
            int number3 = 7854;
            Console.WriteLine($"{number1} is palindrome: {IsPalindrome(number1)}");
            Console.WriteLine($"{number2} is palindrome: {IsPalindrome(number2)}");
            Console.WriteLine($"{number3} is palindrome: {IsPalindrome(number3)}");
        }
        private static bool IsPalindrome(int number)
        {
            if (number < 0) return false;
            int original = number;
            int reversed = 0;
            while (number > 0)
            {
                int remainder = number % 10;
                reversed = (reversed * 10) + remainder;
                number /= 10;
            }
            return original == reversed;
        }


        public static void Task3()
        {
            int[] originalArray = { 1, 2, 6, -1, 88, 7, 6 };
            int[] filterArray = { 6, 88, 7 };
            Console.WriteLine("Original array: ", originalArray);
            FilterArray(ref originalArray, filterArray, out int count);
            Console.WriteLine("Filtered array: ", originalArray);
            Console.WriteLine("Removed count: ", count);
        }
        public static void FilterArray(ref int[] original, int[] filter, out int count)
        {
            count = 0;
            int targetIndex = 0;
            for (int i = 0; i < original.Length; i++)
            {
                if (Contains(filter, original[i])) count++;
                else
                {
                    original[targetIndex] = original[i];
                    targetIndex++;
                } 
            }
            Array.Resize(ref original, targetIndex);
        }
        private static bool Contains(int[] filter, int element)
        {
            for (int i = 0; i < filter.Length; i++)
            {
                if (filter[i] == element) return true;
            }
            return false;
        }
    }
}
