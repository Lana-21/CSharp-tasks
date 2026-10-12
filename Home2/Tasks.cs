using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Home2
{
    internal class Tasks
    {
        public static void Task1()
        {
            Random random = new Random();
            double[] A = new double[5];
            double[,] B = new double[3, 4];
            Console.WriteLine("Enter 5 double numbers for Array A:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"A[{i}] = ");
                A[i] = Convert.ToDouble(Console.ReadLine());
            }
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    B[i, j] = random.NextDouble() * 10;
            double max = A[0], min = A[0], totalSum = 0, totalProduct = 1, evenSum = 0, oddCol = 0;
            Console.WriteLine("\nArray A:");
            foreach (var el in A)
            {
                Console.Write($"{el,6:F1}");
                if (el > max) max = el;
                if (el < min) min = el;
                totalSum += el;
                totalProduct *= el;
                if (el % 2 == 0) evenSum += el;
            }
            Console.WriteLine("\n\nArray B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    double el = B[i, j];
                    Console.Write($"{el,6:F1}");
                    if (el > max) max = el;
                    if (el < min) min = el;
                    totalSum += el;
                    totalProduct *= el;
                    if (j % 2 == 0) oddCol += el; 
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nResults:");
            Console.WriteLine($"Max element: {max,6:F1}\nMin element: {min,6:F1}");
            Console.WriteLine($"Total sum: {totalSum,6:F1}\nTotal product: {totalProduct,6:F1}");
            Console.WriteLine($"Sum of even elements in A: {evenSum,6:F1}");
            Console.WriteLine($"Sum of odd columns in B: {oddCol,6:F1}");
        }

        public static void Task2()
        {
            Random random = new Random();
            int[,] array = new int[5, 5];
            Console.WriteLine("array 5x5:");
            int minVal = int.MaxValue;
            int maxVal = int.MinValue;
            int minIndex = 0, maxIndex = 0, counter = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int val = random.Next(-100, 101);
                    array[i, j] = val;
                    Console.Write($"{val,6}");
                    if (val < minVal) (minVal, minIndex) = (val, counter);
                    if (val > maxVal) (maxVal, maxIndex) = (val, counter);
                    counter++;
                }
                Console.WriteLine();
            }
            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);
            int sum = 0;
            int index = 0;
            foreach (int val in array)
            {
                if (index > start && index < end) sum += val;
                index++;
            }
            Console.WriteLine($"\nMin element: {minVal,6}");
            Console.WriteLine($"Max element: {maxVal,6}");
            Console.WriteLine($"Sum between min and max: {sum,6}");
        }

        public static void Task3()
        {
            Console.WriteLine("Enter a string to encrypt:");
            string input = Console.ReadLine();
            int move = 3;
            string encrypted = Transform(input, move);
            string decrypted = Transform(encrypted, -move);
            Console.WriteLine($"\nOriginal:  {input}");
            Console.WriteLine($"Encrypted: {encrypted}");
            Console.WriteLine($"Decrypted: {decrypted}");
        }
        public static string Transform(string text, int move)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    buffer[i] = (char)(offset + (c - offset + move + 26) % 26);
                }
            }
            return new string(buffer);
        }

        public static void Task4()
        {
            Random random = new Random();
            int[,] A = CreateArray(3, 3, random);
            int[,] B = CreateArray(3, 3, random);
            int numb = 4;
            Console.WriteLine("Array A:");
            Print(A);
            Console.WriteLine("Array B:");
            Print(B);
            Console.WriteLine($"1. Array A * {numb}:");
            Print(MultiplyByNumber(A, numb));
            Console.WriteLine("2. Array A + Array B:");
            Print(Add(A, B));
            Console.WriteLine("3. Array A * Array B:");
            Print(Multiply(A, B));
        }
        public static int[,] CreateArray(int rows, int cols, Random random)
        {
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = random.Next(1, 10);
            return result;
        }
        public static void Print(int[,] array)
        {
            Console.WriteLine(); 
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($" {array[i, j],6}");
                }
                Console.WriteLine();
            }
        }
        public static int[,] MultiplyByNumber(int[,] array, int number)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = array[i, j] * number;
                }
            }
            return result;
        }
        public static int[,] Add(int[,] A, int[,] B)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                }
            }
            return result;
        }
        public static int[,] Multiply(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);
            int[,] result = new int[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return result;
        }

        public static void Task5()
        {
            Console.WriteLine("Enter an arithmetic expression (use + and - only): ");
            string input = Console.ReadLine();
            string formatted = input.Replace(" ", "").Replace("-", "+-");
            string[] parts = formatted.Split('+');
            double result = 0;
            foreach (var part in parts)
            {
                if (double.TryParse(part, out double number)) result += number;
                else Console.WriteLine($"Invalid element: '{part}'");
            }
            Console.WriteLine($"Result: {result}");
        }
        public static void Task6()
        {
            Console.WriteLine("Enter a text:");
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            bool newSentence = true;
            for (int i = 0; i < chars.Length; i++)
            {
                if (newSentence && char.IsLetter(chars[i]))
                {
                    chars[i] = char.ToUpper(chars[i]);
                    newSentence = false;
                }
                else if (chars[i] == '.' || chars[i] == '!' || chars[i] == '?')
                {
                    newSentence = true;
                }
            }
            string result = new string(chars);
            Console.WriteLine($"\nResult: {result}");
        }

        public static void Task7()
        {
            string text = """
                To be, or not to be, that is the question,
                Whether 'tis nobler in the mind to suffer
                The slings and arrows of outrageous fortune,
                Or to take arms against a sea of troubles,
                And by opposing end them? To die: to sleep;
                No more; and by a sleep to say we end
                The heart-ache and the thousand natural shocks
                That flesh is heir to, 'tis a consummation
                Devoutly to be wish'd. To die, to sleep
                """;
            Console.WriteLine(text);
            Console.Write("\nEnter search word: ");
            string word = Console.ReadLine();
            int count = 0;
            string star = new string('*', word.Length); 
            while (text.ToLower().Contains(word.ToLower()))
            {
                int index = text.ToLower().IndexOf(word.ToLower());
                text = text.Remove(index, word.Length).Insert(index, star);
                count++; 
            }
            Console.WriteLine("\nResult:");
            Console.WriteLine(text);
            Console.WriteLine($"\nStatistics: {count} replacements of word '{word}'.");
        }
    }
}
    
  
 
