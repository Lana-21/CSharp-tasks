namespace Practice8InterfaceHome8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyArray defArray = new MyArray();
            Console.WriteLine("Default Array");
            defArray.Show();
            MyArray someArray = new MyArray(10, 20, 30, 40, 50);
            Console.WriteLine("\nTest Show");
            someArray.Show();
            Console.WriteLine("\nTest Show (string)");
            someArray.Show("Array result");
            Console.WriteLine();

            Console.WriteLine($"Max value: {someArray.Max()}");
            Console.WriteLine($"Min value: {someArray.Min()}");
            Console.WriteLine($"Average value: {someArray.Avg()}");
            int search1 = 20;
            int search2 = 11;
            Console.WriteLine($"Search for {search1}: {someArray.Search(search1)}");
            Console.WriteLine($"Search for {search2}: {someArray.Search(search2)}");

            Console.WriteLine("\nTest ICalc");
            int compareVal = 30;
            Console.WriteLine($"Elements less than {compareVal}: {someArray.Less(compareVal)}");
            Console.WriteLine($"Elements greater than {compareVal}: {someArray.Greater(compareVal)}");

            Console.WriteLine("\nTest IOutput2");
            someArray.ShowEven();
            someArray.ShowOdd();

            Console.WriteLine("\nTest ICalc2");
            Console.WriteLine($"Count of distinct values: {someArray.CountDistinct()}");
            int target = 20;
            Console.WriteLine($"Elements equal to {target}: {someArray.EqualToValue(target)}");

            Console.ReadKey();
        }
    }
}
