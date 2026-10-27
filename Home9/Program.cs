namespace Home9Delegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            //int[] arr = { 23, 41, 7, 14, 2, 10, 11, 13, 17, 20 };
            //Console.WriteLine("This array: " + string.Join(", ", arr));
            //Predicate<int> isEven = n => n % 2 == 0;
            //int[] evens = ArrayProcess.FilterArray(arr, isEven);
            //Console.WriteLine("Even numbers: " + string.Join(", ", evens));
            //Predicate<int> isOdd = n => n % 2 != 0;
            //int[] odds = ArrayProcess.FilterArray(arr, isOdd);
            //Console.WriteLine("Odd numbers: " + string.Join(", ", odds));
            //Predicate<int> isSimple = ArrayProcess.IsSimple;
            //int[] simple = ArrayProcess.FilterArray(arr, isSimple);
            //Console.WriteLine("Simple numbers: " + string.Join(", ", simple));
            //Predicate<int> isFib = ArrayProcess.IsFibonacci;
            //int[] fibs = ArrayProcess.FilterArray(arr, isFib);
            //Console.WriteLine("Fibonacci numbers: " + string.Join(", ", fibs));
            //Console.ReadKey();


            //завдання2
            //Action showTime = Geometry.ShowCurrentTime;
            //Action showDate = Geometry.ShowCurrentDate;
            //Action showDayOfWeek = Geometry.ShowCurrentDayOfWeek;
            //Console.WriteLine("Time and Date Information");
            //showTime.Invoke();
            //showDate.Invoke();
            //showDayOfWeek.Invoke();
            //Predicate<double> isValidValue = Geometry.IsValidValue;
            //Func<double, double, double> triangleArea = Geometry.CalculateTriangleArea;
            //Func<double, double, double> rectangleArea = Geometry.CalculateRectangleArea;
            //double a = 22.7;
            //double b = 11.1;
            //Console.WriteLine("Calculations");
            //if (isValidValue(a) && isValidValue(b))
            //{
            //    double tArea = triangleArea.Invoke(a, b);
            //    Console.WriteLine($"Triangle area: {tArea}");
            //    double rArea = rectangleArea.Invoke(a, b);
            //    Console.WriteLine($"Rectangle area: {rArea}");
            //}
            //else Console.WriteLine("Error");
            //Console.ReadKey();



            //завдання3
            //string text = "C# is powerful programming language";
            //string target = "programming";
            //Console.WriteLine($"Text: {text}");
            //Console.WriteLine($"Target word: {target}");
            //bool result = Text.ContainsWord(text, target);
            //if (result) Console.WriteLine($"Result: The text contains the word {target}");
            //else Console.WriteLine($"Result: The text not contain the word {target}");
            //string missingWord = "CPP";
            //Console.WriteLine($"\nTarget word: {missingWord}");
            //if (Text.ContainsWord(text, missingWord)) Console.WriteLine($"Result: The text contains the word {missingWord}");
            //else Console.WriteLine($"Result: The text not contain the word {missingWord}");
            //Console.ReadKey();



            //завдання4
            //int[] numbers = { 7, 14, 25, 21, 32, 35, 42 };
            //Console.WriteLine("Array: " + string.Join(", ", numbers));
            //Console.WriteLine();
            //int result = ArraySeven.CountSeven(numbers);
            //Console.WriteLine($"Count of numbers multiples of 7: {result}");
            //Console.ReadKey();


            //завдання5
            //int[] numbers = { -5, 10, 0, -3, 14, 7, -2, 22 };
            //Console.WriteLine("Array: " + string.Join(", ", numbers));
            //Console.WriteLine();
            //int result = Positive.CountPositive(numbers);
            //Console.WriteLine($"Count of positive numbers: {result}");
            //Console.ReadKey();



            //завдання6
            //int[] numbers = { -5, 54, -2, -5, 110, -3, -2, 10, -3 };
            //Console.WriteLine("Array: " + string.Join(", ", numbers));
            //Console.WriteLine();
            //int[] uniqueNegatives = Negative.GetUniqueNegative(numbers);
            //Console.WriteLine("Unique negative numbers: " + string.Join(", ", uniqueNegatives));
            //Console.ReadKey();


            //завдання7
            //string[] testStrings = {
            //"{}[]",     
            //"(())",   
            //"[{}]",    
            //"]}[",      
            //"[[{}]"   
            //};
            //Console.WriteLine("Bracket validation results:\n");
            //foreach (string s in testStrings)
            //{
            //    bool result = s.IsValidBrackets();
            //    Console.WriteLine($"{s} -> {result}");
            //}
            //Console.ReadKey();



            //завдання8
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Original array: " + string.Join(", ", numbers));
            Console.WriteLine();
            int[] evenNumbers = numbers.Filter(n => n % 2 == 0);
            Console.WriteLine("Even numbers:   " + string.Join(", ", evenNumbers));
            int[] oddNumbers = numbers.Filter(n => n % 2 != 0);
            Console.WriteLine("Odd numbers:    " + string.Join(", ", oddNumbers));
            Console.ReadKey();
        }
    }
}

