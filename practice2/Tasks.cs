using System;
using System.Collections.Generic;
using System.Text;

namespace Practice2
{
    internal class Tasks
    {
        public static void FillArray(int[] array, Random random, int minValue = 1, int maxValue = 50)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
        }
        public static void PrintArray(int[] array)
        {
            Console.WriteLine("Array:");
            foreach (var el in array)
            {
                Console.Write($" {el}");
            }
            Console.WriteLine();
        }
        public static void Task1()
        {
            Random random = new Random();
            Console.WriteLine("Input size array: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array1 = new int[n];
            FillArray(array1, random, 1, 50);
            PrintArray(array1);
            Console.WriteLine($"Even elements count: {EvenCount(array1)}");
            Console.WriteLine($"Odd elements count: {OddCount(array1)}");
            Console.WriteLine($"Unique elements count: {UniqueCount(array1)}");
            Console.WriteLine();
        }
        public static int EvenCount(int[] array)
        {
            int count = 0;
            foreach (var el in array)
            {
                if (el % 2 == 0) count++;
            }
            return count;
        }
        public static int OddCount(int[] array)
        {
            int count = 0;
            foreach (var el in array)
            {
                if (el % 2 != 0) count++;
            }
            return count;
        }
        public static int UniqueCount(int[] array)
        {
            int count = 0;
            foreach (int el in array)
            {
                if (Array.IndexOf(array, el) == Array.LastIndexOf(array, el))
                {
                    count++;
                }
            }
            return count;
        }

        public static void Task2()
        {
            Random random = new Random();
            Console.WriteLine("Input size array: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array1 = new int[n];
            FillArray(array1, random, 1, 30);
            PrintArray(array1);
            Console.WriteLine("Enter limit value: ");
            int limit = Convert.ToInt32(Console.ReadLine());
            int count = GetLessThan(array1, limit);
            Console.WriteLine($"elements less than {limit}: {count}");
            Console.WriteLine();
        }
        private static int GetLessThan(int[] array, int limit)
        {
            int count = 0;
            foreach (var el in array)
            {
                if (el < limit) count++;
            }
            return count;
        }

        public static void Task4()
        {
            Random random = new Random();
            Console.WriteLine("Input size M for Array 1: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input size N for Array 2: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array1 = new int[m];
            FillArray(array1, random, -22, 22);
            int[] array2 = new int[n];
            FillArray(array2, random, -22, 22);
            Console.WriteLine("Array 1:");
            foreach (var el in array1)
            {
                Console.Write($" {el,5:D}");
            }
            Console.WriteLine("\nArray 2:");
            foreach (var el in array2)
            {
                Console.Write($" {el,5:D}");
            }
            int[] array3 = new int[0];
            foreach (int el in array1)
            {
                if (Array.IndexOf(array2, el) != -1 && Array.IndexOf(array3, el) == -1)
                {
                    Array.Resize(ref array3, array3.Length + 1);
                    array3[array3.Length - 1] = el;
                }
            }
            Console.WriteLine("\nArray 3 Common elements :");
            foreach (var el in array3)
            {
                Console.Write($" {el,5:D}");
            }
            Console.WriteLine();
        }
      
        public static void Task6()
        {
            Console.WriteLine("Enter a sentence:");
            string input = Console.ReadLine();
            string[] words = input.Split(new char[] { ' ', ':', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var el in words)
            {
                Console.WriteLine(el);
            }
            string s = string.Join(' ', words);
            Console.WriteLine($"Word count = {words.Length}\n Words\n{s}");
            Console.WriteLine();
        }
    }
}
    
