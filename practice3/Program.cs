using System;
using System.Text;

namespace Practice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            //    Console.OutputEncoding = Encoding.UTF8;
            //    int begin;
            //    Console.WriteLine("Введіть початок діапазону ");
            //    begin = int.Parse(Console.ReadLine());
            //    if (int.TryParse(Console.ReadLine(), out int end)) { }
            //    if (begin > end)
            //    {
            //        //int buf = begin;
            //        //begin = end;
            //        //end = buf;
            //        (begin, end) = (end, begin);
            //    }
            //    long prod = ProductNumber(begin, end);
            //    Console.WriteLine($"Product of numbers from the range {begin},{end}) ={prod} ");
            //}
            //private static long ProductNumber(int begin, int end)
            //{
            //    long pr = 1;
            //    for (; begin < end; begin++)
            //    {
            //        pr *= begin;
            //    }
            //    return pr;


            //завдання3
            //    int[][] myArray = new int[][]
            //        {
            //                new int[] { 1, 2, 3 },
            //                new int[] { 4, 5 },
            //                new int[] { 6, 7, 8, 9 }
            //        };
            //    PrintArray(myArray);
            //    AddElementArray(myArray);
            //    Console.WriteLine("\nNew array:");
            //    PrintArray(myArray);
            //}
            //public static void PrintArray(int[][] array)
            //{
            //    for (int i = 0; i < array.Length; i++)
            //    {
            //        Console.Write($"Line {i}: ");
            //        for (int j = 0; j < array[i].Length; j++)
            //        {
            //            Console.Write($"{array[i][j]} ");
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //public static void AddElementArray(int[][] array)
            //{
            //    for (int i = 0; i < array.Length; i++)
            //    {
            //        AddSumItemArray(ref array[i]);
            //    }
            //}
            //private static void AddSumItemArray(ref int[] ints)
            //{
            //    int sum = 0;
            //    for (int i = 0; i < ints.Length; i++)
            //    {
            //        sum += ints[i];
            //    }
            //    int oldLen = ints.Length;
            //    Array.Resize(ref ints, oldLen + 1);
            //    ints[oldLen] = sum;
            //}


            //завдання4
            string text = "  «Hello, stats!» — said Tom (test, radar). Is it a status, or a strategy?; ";
            string result = ProcessString(text);
            Console.WriteLine("Original text:");
            Console.WriteLine(text);
            Console.WriteLine("\nProcessed text:");
            Console.WriteLine(result);
        }
        private static string ProcessString(string input)
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                int firstLetterIndx = Array.FindIndex(words[i].ToCharArray(), char.IsLetter);
                if (firstLetterIndx != -1)
                {
                    char firstChar = char.ToLower(words[i][firstLetterIndx]);
                    if (words[i].ToLower().IndexOf(firstChar, firstLetterIndx + 1) != -1)
                    {
                        words[i] = words[i].ToUpper();
                    }
                }
            }
            return string.Join(" ", words);
        }


        //завдання5
        //int[] numbers = { 1, 2, 3 };
        //MyAddRange(ref numbers, 4, 5, 6, 7);
        //Console.WriteLine(string.Join(", ", numbers));
        //}
        //public static void MyAddRange(ref int[] array, params int[] items)
        //{
        //    if (items.Length == 0) return;
        //    int oldLength = array.Length;
        //    Array.Resize(ref array, oldLength + items.Length);
        //    Array.Copy(items, 0, array, oldLength, items.Length);
        //}
    }
}



