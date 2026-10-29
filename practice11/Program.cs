using System.Numerics;
using static System.Console;
namespace Practice11GENERICS
{
    class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            //static T MinElem<T>(T[] arr) where T : IComparable<T>
            //{
            //    T min = arr[0];
            //    foreach (T item in arr)
            //    {
            //        if (item.CompareTo(min) < 0)
            //            min = item;
            //    }
            //    return min;
            //}
            //static T MaxElem<T>(T[] arr) where T : IComparable<T>
            //{
            //    T max = arr[0];
            //    foreach (T item in arr)
            //    {
            //        if (item.CompareTo(max) > 0)
            //            max = item;
            //    }
            //    return max;
            //}
            //static void Main(string[] args)
            //{
            //    int[] arrInt = new int[] {  66, 18, 114 };
            //    WriteLine($"Minimum element: {MinElem<int>(arrInt)}");
            //    WriteLine($"Maximum element: {MaxElem<int>(arrInt)}");
            //}


            //завдання2
            //static T SumElem<T>(T[] arr) where T : INumber<T>
            //{
            //    if (arr == null)
            //    {
            //        throw new ArgumentException("The array is empty");
            //    }
            //    T sum = T.Zero;
            //    foreach (T item in arr)
            //    {
            //        sum += item;
            //    }
            //    return sum;
            //}
            //static void Main(string[] args)
            //{
            //    int[] arrInt = new int[] { 10, 20, 30, 40 };
            //    try
            //    {
            //        WriteLine($"Sum of array: {SumElem<int>(arrInt)}");
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        WriteLine($"Error: {ex.Message}");
            //    }
            //}


            //завдання3
            Point<double> p1 = new(0.0, 0.0);
            Point<double> p2 = new(3.0, 4.0);
            Line<double> line1 = new(p1, p2);
            WriteLine(line1);
            WriteLine($"length: {line1.GetLength()}");
            Point<double> testPoint = new(1.5, 2.0);
            WriteLine($"Is point {testPoint} on the line? {line1.IsPointOnLine(testPoint)}");
            WriteLine();


            //завдання4
            Animal[] animals =
            {
                new Dolphin("Dolphin", 5, "Dolphin"),
                new Shark("Shark", 7, 3.5)
            };
            try
            {
                Oceanarium oceanarium = new(animals);
                foreach (var animal in oceanarium)
                {
                    Console.WriteLine(animal);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
