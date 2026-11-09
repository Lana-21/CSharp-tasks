using static System.Console;
namespace Home15GC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання1
        //    WriteLine("Play Catalog");
        //    List<Play> catalog = new()
        //        {
        //            new Play(),
        //            new Play("Hamlet", "William Shakespeare", PlayGenre.Tragedy, 1603),
        //            new Play("The Seagull", "Anton Chekhov", PlayGenre.Drama, 1896),
        //            new Play("The Inspector General", "Mykola Gogol", PlayGenre.Comedy, 1836)
        //        };
        //    WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
        //    int searchYear = 1603;
        //    WriteLine($"Plays released in {searchYear}: ");
        //    var filteredByYear = catalog.Where(p => p.ReleaseYear == searchYear);
        //    foreach (var play in filteredByYear)
        //    {
        //        play.Display();
        //    }
        //    WriteLine("\nChecking Dispose and GC.SuppressFinalize");
        //    WriteLine("\nCreating a play:");
        //    using (Play disposablePlay = new Play("Shakespeare", "William Shakespeare", PlayGenre.Tragedy, 1606))
        //    {
        //        disposablePlay.Display();
        //        WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
        //    }
        //    CreateForgottenPlay();
        //    WriteLine("\nRunning Garbage Collector");
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
        //    ReadKey();
        //}
        //static void CreateForgottenPlay()
        //{
        //    Play forgotten = new Play("Othello", "William Shakespeare", PlayGenre.Tragedy, 1604);
        //    forgotten.Display();
        //    WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
        //}



        //завдання2
        WriteLine("Shop Catalog");
            List<Shop> catalog = new()
            {
                new Shop(),
                new Shop("Silpo", "Shevchenka St, 10", ShopType.Grocery),
                new Shop("Epicentr", "Khreshchatyk St, 2", ShopType.Household)
            };
            WriteLine($"\nTotal shop objects created: {Shop.TotalShopsCreated}\n");
            ShopType searchType = ShopType.Grocery;
            WriteLine($"Shops of type {searchType}: ");
            var filteredByType = catalog.Where(s => s.Type == searchType);
            foreach (var shop in filteredByType)
            {
                shop.Display();
            }
            WriteLine("\nChecking Dispose and GC.SuppressFinalize");
            WriteLine("\nCreating a shop:");
            using (Shop disposableShop = new Shop("ATB", "Peremohy, 45", ShopType.Grocery))
            {
                disposableShop.Display();
                WriteLine($"\nTotal shop objects created: {Shop.TotalShopsCreated}\n");
            }
            CreateForgottenShop();
            WriteLine("\nRunning Garbage Collector");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            WriteLine($"\nTotal shop objects created: {Shop.TotalShopsCreated}\n");
            ReadKey();
        }
        static void CreateForgottenShop()
        {
            Shop forgotten = new Shop("MegaMarket", "Bandera St, 36", ShopType.Household);
            forgotten.Display();
            WriteLine($"\nTotal shop objects created: {Shop.TotalShopsCreated}\n");
        }
    }
}
