using System;
using System.Text;

namespace ConsAppException
{
    internal class Program
    {
        //завдання 7
        //static public long Calculate(string expression)
        //{
        //    if (string.IsNullOrEmpty(expression))
        //    {
        //        throw new ArgumentException("Error: The expression cannot be empty!");
        //    }
        //    string[] parts = expression.Split('*');
        //    long result = 1;
        //    foreach (string part in parts)
        //    {
        //        long number = long.Parse(part);
        //        result *= number;
        //    }
        //    return result;
        //}
        //static void Main(string[] args)
        //{
        //Console.WriteLine("Enter an expression:");
        //string input = Console.ReadLine();
        //try
        //{
        //    long calcResult = Calculate(input);
        //    Console.WriteLine($"Result of the expression: {calcResult}");
        //}
        //catch (FormatException my)
        //{
        //    Console.WriteLine("Format Error: " + my.Message);
        //}
        //catch (OverflowException my)
        //{
        //    Console.WriteLine("Overflow Error: " + my.Message);
        //}
        //catch (ArgumentException my)
        //{
        //    Console.WriteLine("Argument Error: " + my.Message);
        //}
        //catch (Exception my)
        //{
        //    Console.WriteLine("Error: " + my.Message);
        //}



        //завдання 2
        //string input;
        //int result = 0;
        //do
        //{
        //    Console.WriteLine($"Enter a string of digits (0-9) in range from {int.MinValue} to {int.MaxValue}:");
        //    Console.WriteLine("enter '0' to exit:");
        //    try
        //    {
        //        input = Console.ReadLine();
        //        if (input == "0") {break;}
        //        result = int.Parse(input);
        //        Console.WriteLine($"Successfully converted to number: {result}");
        //    }
        //    catch (FormatException my)
        //    {
        //        Console.WriteLine("Format Error: " + my.Message);
        //    }
        //    catch (OverflowException my)
        //    {
        //        Console.WriteLine("Overflow Error: " + my.Message);
        //    }
        //    catch (Exception my)
        //    {
        //        Console.WriteLine("Error: " + my.Message);
        //    }
        //} while (true);
        //}


        //завдання 4
        static public bool Logical(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("Error: The expression cannot be empty!");
            }
            string[] operators = { "<=", ">=", "==", "!=", "<", ">" };
            string symbol = "";
            string[] parts = null;
            foreach (var item in operators)
            {
                if (expression.Contains(item))
                {
                    symbol = item;
                    parts = expression.Split(new string[] { symbol }, StringSplitOptions.None);
                    break;
                }
            }
            if (parts == null || parts.Length != 2)
            {
                throw new FormatException("Error: Invalid expression format or operator!");
            }
            int leftNum = int.Parse(parts[0]);
            int rightNum = int.Parse(parts[1]);
            switch (symbol)
            {
                case "<":
                    return leftNum < rightNum;
                case ">":
                    return leftNum > rightNum;
                case "<=":
                    return leftNum <= rightNum;
                case ">=":
                    return leftNum >= rightNum;
                case "==":
                    return leftNum == rightNum;
                case "!=":
                    return leftNum != rightNum;
                default:
                    throw new FormatException("Error: Invalid operator!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a logical expression: ");
            string input = Console.ReadLine();
            try
            {
                bool result = Logical(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException my)
            {
                Console.WriteLine("Format Error: " + my.Message);
            }
            catch (OverflowException my)
            {
                Console.WriteLine("Overflow Error: " + my.Message);
            }
            catch (ArgumentException my)
            {
                Console.WriteLine("Argument Error: " + my.Message);
            }
            catch (Exception my)
            {
                Console.WriteLine("Error: " + my.Message);
            }
        }
    }
}

