using static System.Console;
namespace Home6
{
    internal class Program
    {
        //завдання1
        //    static void Main(string[] args)
        //    {
        //        Shop shop1;
        //        Shop shop2;
        //        try
        //        {
        //            shop1 = new Shop("Supermarket", "Khreshchatyk 1", 450.5);
        //            shop2 = new Shop("Supermarket", "Shevchenko 10", 120.0);
        //            WriteLine(shop1);
        //            WriteLine(shop2);
        //            WriteLine("Comparison Operators:");
        //            WriteLine($"shop1 == shop2: {shop1 == shop2}");
        //            WriteLine($"shop1 != shop2: {shop1 != shop2}");
        //            WriteLine($"shop1 > shop2: {shop1 > shop2}");
        //            WriteLine($"shop1 < shop2: {shop1 < shop2}");
        //            WriteLine($"shop1.Equals(shop2): {shop1.Equals(shop2)}");
        //            WriteLine("Modifying Area Using + and - :");
        //            shop1 = shop1 + 55.0;
        //            WriteLine($"Shop 1 area after adding 55 sq.m: {shop1.Area}");
        //            shop2 = shop2 - 22.0;
        //            WriteLine($"Shop 2 area after subtracting 22 sq.m: {shop2.Area}");
        //            WriteLine("Entering New Shop Data:");
        //            Shop shop3 = new Shop();
        //            shop3.InputData();
        //            WriteLine("\nNew Shop:");
        //            WriteLine(shop3);
        //        }
        //        catch (ArgumentException my)
        //        {
        //            WriteLine("Argument Error: " + my.Message);
        //        }
        //        catch (Exception my)
        //        {
        //            WriteLine("Error: " + my.Message);
        //        }
        //        WriteLine("\nPress any key to exit ");
        //        ReadKey();
        //    }

        //завдання2
        static void Main(string[] args)
        {
            Person author1;
            Magazine mag1;
            Magazine mag2;
            try
            {
                author1 = new Person("Taras", "Shevchenko", new DateTime(1999, 5, 10));
                mag1 = new Magazine("My World", Frequency.Monthly, DateTime.Now, 5000, 20);
                mag1.AddArticles(new Article(author1, "C# Language", 9.5));
                mag2 = new Magazine("Shop", Frequency.Weekly, DateTime.Now, 12000, 8);
                WriteLine(mag1);
                WriteLine(mag2);
                WriteLine();
                WriteLine($"mag1 == mag2: {mag1 == mag2}");
                WriteLine($"mag1 > mag2: {mag1 > mag2}");
                WriteLine($"mag1 < mag2: {mag1 < mag2}");
                WriteLine();
                mag1 = mag1 + 7;
                WriteLine($"Mag1 employees after adding 7: {mag1.EmployeesCount}");
                mag2 = mag2 - 6;
                WriteLine($"Mag2 employees after subtracting 6: {mag2.EmployeesCount}");
            }
            catch (ArgumentException my)
            {
                WriteLine("Argument Error: " + my.Message);
            }
            catch (Exception my)
            {
                WriteLine("An unexpected error occurred: " + my.Message);
            }
            WriteLine("\nPress any key to exit ");
            ReadKey();
        }
    }
}
