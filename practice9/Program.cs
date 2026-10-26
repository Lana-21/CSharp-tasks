using System;
namespace Practice9Delegate
{
    class Program
    {
        //завдання1
        //delegate void MessageDelegate(string message);
        //static void PrintStandard(string msg)
        //{
        //    Console.WriteLine($"Standard text: {msg}");
        //}
        //static void PrintUppercase(string msg)
        //{
        //    Console.WriteLine($"Uppercase text: {msg.ToUpper()}");
        //}
        //static void Main(string[] args)
        //{
        //    MessageDelegate messageDel = PrintStandard;
        //    messageDel += PrintUppercase;
        //    messageDel("Hello world");
        //}



        //завдання2
        //delegate double Operation(double a, double b);
        //static void Main(string[] args)
        //{
        //    double num1 = 15.5;
        //    double num2 = 4.5;
        //    Operation add = MathOperations.Add;
        //    Operation subtract = MathOperations.Subtract;
        //    Operation multiply = MathOperations.Multiply;
        //    Console.WriteLine($"Numbers: num1 = {num1}, num2 = {num2}\n");
        //    Console.WriteLine($"num1 + num2 = {add.Invoke(num1, num2)}");
        //    Console.WriteLine($"num1 - num2 = {subtract.Invoke(num1, num2)}");
        //    Console.WriteLine($"num1 * num2 = {multiply.Invoke(num1, num2)}");
        //    Console.ReadKey();
        //}

        //завдання5
        //static void Main(string[] args)
        //{
        //    Func<double, double> cube = n => n * n * n;
        //    double n = 5.13;
        //    double result = cube(n);
        //    Console.WriteLine($"The cube of {n} is {result}");
        //}


        //завдання6
        //static void Main(string[] args)
        //{
        //    int[] arr = { 45, 12, 33, 8, 5, 11 };
        //    Predicate<int> isOdd = el => el % 2 != 0;
        //    Console.WriteLine("Array: " + string.Join(", ", arr));
        //    Console.WriteLine("Odd numbers:");
        //    foreach (var el in arr)
        //    {
        //        if (isOdd(el)) Console.Write(el + " ");
        //    }
        //    Console.ReadKey();
        //}


        //завдання8
        //static void Main(string[] args)
        //{
        //    string text = "Anna book shop and level book Radar table civic";
        //    int result = text.CountWords();
        //    Console.WriteLine($"Text: {text}");
        //    Console.WriteLine($"Result: {result}");
        //    Console.ReadKey();
        //}


        //завдання9
        static void Main(string[] args)
        {
            Predicate<int> isSimpleDelegate = IsSimple;
            int test = 17;
            bool result = isSimpleDelegate(test);
            Console.WriteLine($"Is the number {test} simple: {result}");
            Console.WriteLine();
            Func<DateTime, DateTime, int> daysBetweenDelegate = GetDaysBetween;
            DateTime startDate = new DateTime(2028, 5, 5);
            DateTime endDate = DateTime.Now;
            int daysResult = daysBetweenDelegate(startDate, endDate);
            Console.WriteLine($"Number of days between {startDate:d} and {endDate:d}: {daysResult}");
            Console.ReadKey();
        }
        static bool IsSimple(int number)
        {
            if (number <= 1 || (number % 2 == 0 && number != 2)) return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static int GetDaysBetween(DateTime date1, DateTime date2)
        {
            int days = (int)(date2 - date1).TotalDays; ;
            return Math.Abs(days);
        }

    }
}
