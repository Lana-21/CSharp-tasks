using System;
using static System.Console;
namespace Practice10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            //int[] numbers = { 5, 12, 8, 3, 19, 22, 7, 10 };
            //WriteLine("Original array: " + string.Join(", ", numbers));
            //int[] evens = numbers.Filter(n => n % 2 == 0);
            //WriteLine("Even numbers: " + string.Join(", ", evens));
            //int[] odds = numbers.Filter(n => n % 2 != 0);
            //WriteLine("Odd numbers: " + string.Join(", ", odds));
            //ReadKey();


            //завдання2
            //Person[] people = new Person[]
            //{
            //   new Person { FirstName = "Oleksandr", LastName = "Petrenko", Age = 52 },
            //   new Person { FirstName = "Maria", LastName = "Kovalenko", Age = 19 },
            //   new Person { FirstName = "Ivan", LastName = "Shevchenko", Age = 40 },
            //   new Person { FirstName = "Olena", LastName = "Melnyk", Age = 10 }
            //};
            //WriteLine("List of people");
            //foreach (var p in people)
            //{
            //    WriteLine($"{p.FirstName} {p.LastName}, {p.Age} years old");
            //}
            //WriteLine();
            //Person youngest = people.GetYoungest();
            //Person oldest = people.GetOldest();
            //double averageAge = people.GetAverageAge();
            //WriteLine($"Youngest person: {youngest.FirstName} {youngest.LastName} ({youngest.Age} years old)");
            //WriteLine($"Oldest person: {oldest.FirstName} {oldest.LastName} ({oldest.Age} years old)");
            //WriteLine($"Average age: {averageAge} years");



            //завдання3
            Backpack backpack = new Backpack("Black", "Nike", 0.7, 10.0);
            backpack.ItemAdded += msg => WriteLine($"EVENT: {msg}");
            backpack.ItemRemoved += msg => WriteLine($"EVENT: {msg}");
            try
            {
                backpack.Put(new Item("Laptop", 5.0));
                backpack.Put(new Item("Book", 2.0));
                backpack.Put(new Item("Big Box", 6.0));
            }
            catch (InvalidOperationException ex)
            {
                WriteLine($"EXCEPTION: {ex.Message}");
            }
            try
            {
                backpack.Remove("Book");
                backpack.Remove("Phone");
            }
            catch (ArgumentException ex)
            {
                WriteLine($"EXCEPTION: {ex.Message}");
            }
            ReadKey();
        }
    }
}
    
