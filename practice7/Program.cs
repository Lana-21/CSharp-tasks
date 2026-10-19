using System;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Toy("Plush Dog", "Toy World", 850.0, 6, "Denmark"),
                new Toy("Plush Bear", "Children's Store", 350.0, 3, "Ukraine"),
                new Product("Plush Cat", "Toy Shop", 505.0),
                new Toy("Doll", "Children's World", 2000.0, 5, "Ukraine"),
                new Toy("Car", "Supermarket", 1100.0, 8, "Denmark")
            };
            Console.WriteLine("ALL PRODUCTS");
            foreach (var item in products)
            {
                item.Passport();
            }
            Console.WriteLine("\nPRODUCTS MADE IN UKRAINE");
            foreach (var item in products)
            {
                if (item is Toy toy && toy.ManufacturePlace.ToLower() == "ukraine") toy.Passport();
            }
            Console.WriteLine("\nTOYS FOR CHILDREN OLDER THAN 4 YEARS");
            foreach (var item in products)
            {
                if (item is Toy toy && toy.AgeCategory > 4) toy.Passport();
            }
            Console.WriteLine("\nEquals");
            Toy copyToy = new Toy("Wooden Puzzle", "EduGames", 200.0, 5, "Ukraine");
            bool areEqual = products[3].Equals(copyToy);
            Console.WriteLine($"Is product[3] equal to copyToy? - {areEqual}");
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
