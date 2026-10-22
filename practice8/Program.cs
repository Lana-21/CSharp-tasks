namespace Practice8Interface
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

            Console.ReadKey();
        }
    }
}
