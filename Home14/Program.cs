using static System.Console;
namespace Practice14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання7
            //int[] numbers = { 1, 2, 8, -6, 4, 2, 7, 9, 16, 5 };
            //WriteLine("Input array: " + string.Join(" ", numbers));
            //int groupIndex = 0;
            //var longest = numbers
            //    .Select(n => new { Number = n, Group = n % 2 == 0 ? groupIndex : ++groupIndex })
            //    .Where(pair => pair.Number % 2 == 0)
            //    .GroupBy(pair => pair.Group)
            //    .Select(group => group.Select(p => p.Number).ToArray())
            //    .OrderByDescending(arr => arr.Length)
            //    .FirstOrDefault();
            //int maxLength = longest != null ? longest.Length : 0;
            //WriteLine($"Length of even numbers: {maxLength}");
            //WriteLine("Array: " + string.Join(" ", longest ?? new int[0]));

            //завдання1
            int[] numbers = { 10, 25, 63, 952, 105, 980, 81, 7, 500 };
            int product = numbers.Aggregate((x, y) => x * y);
            WriteLine($"Product of elements: {product}");
            int countAll = numbers.Count();
            WriteLine($"Number of elements: {countAll}");
            int countDiv9 = numbers.Count(n => n % 9 == 0);
            WriteLine($"Number divisible by 9: {countDiv9}");
            int countDiv7 = numbers.Count(n => n % 7 == 0 && n > 945);
            WriteLine($"Number divisible by 7 and > 945: {countDiv7}");
            int sumAll = numbers.Sum();
            WriteLine($"Sum: {sumAll}");
            int sumEven = numbers.Where(n => n % 2 == 0).Sum();
            WriteLine($"Sum of even: {sumEven}");
            int min = numbers.Min();
            WriteLine($"Minimum: {min}");
            int max = numbers.Max();
            WriteLine($"Maximum: {max}");
            double average = numbers.Average();
            WriteLine($"Average: {average}");


            //завдання2
            int[] numb = { 10, 25, 63, 952, 105, 980, 81, 7, 500 };
            WriteLine("Input array: " + string.Join(", ", numb));
            WriteLine();
            var top3Max = numb.OrderBy(n => n).Skip(numb.Count() - 3);
            WriteLine("Three maximum elements: " + string.Join(", ", top3Max));
            var top3Min = numbers.OrderBy(n => n).Take(3);
            WriteLine("Three minimum elements: " + string.Join(", ", top3Min));


            //завдання3
            int[] data = { 10, 25, 63, 952, 105, 500, 10, 63, 500 };
            WriteLine("Input array: " + string.Join(", ", data));
            WriteLine();
            var eachNumber = data
                .GroupBy(n => n)
                .Select(g => new { Number = g.Key, Count = g.Count() });
            WriteLine("statistics of each number:");
            eachNumber.ToList().ForEach(item => WriteLine($"{item.Number} – {item.Count} times"));
            var evenNumber = data
                .Where(n => n % 2 == 0)
                .GroupBy(n => n)
                .Select(g => new { Number = g.Key, Count = g.Count() });
            WriteLine("statistics of even numbers:");
            evenNumber.ToList().ForEach(item => WriteLine($"{item.Number} – {item.Count} times"));
            var parity = data
                .GroupBy(n => n % 2 == 0 ? "even" : "odd")
                .Select(g => new { Type = g.Key, Count = g.Count() });
            WriteLine("statistics of even and odd numbers:");
                parity.ToList().ForEach(item => WriteLine($"{item.Type} – {item.Count} times"));



            //завдання4
            List<Laptop> laptops = new List<Laptop>
            {
            new Laptop("ZenBook 14", "ASUS", 2.8, 8, 38000.0, 2023),
            new Laptop("MacBook Pro 16", "Apple", 3.2, 12, 95000.0, 2025),
            new Laptop("Pavilion 15", "HP", 2.4, 6, 24000.0, 2022),
            new Laptop("ThinkPad X1", "Lenovo", 3.0, 10, 52000.0, 2023),
            new Laptop("Inspiron 3520", "Dell", 2.0, 4, 18500.0, 2021),
            new Laptop("ROG Strix", "ASUS", 3.5, 14, 78000.0, 2025),
            new Laptop("MacBook Air 13", "Apple", 2.5, 8, 45000.0, 2023),
            new Laptop("IdeaPad 3", "Lenovo", 2.1, 4, 16000.0, 2020)
            };
            WriteLine("ALL LAPTOPS");
            laptops.ForEach(l => WriteLine(l));
            WriteLine();
            WriteLine();
            int totalCount = laptops.Count;
            WriteLine($"number of laptops: {totalCount}");
            double myPrice = 40000.0;
            int countPriceGreater = laptops.Count(l => l.Price > myPrice);
            WriteLine($"laptops with price > {myPrice}: {countPriceGreater}");
            double minRange = 20000.0, maxRange = 60000.0;
            int countInRange = laptops.Count(l => l.Price >= minRange && l.Price <= maxRange);
            WriteLine($"laptops with price between {minRange} and {maxRange}: {countInRange}");
            string targetManufacturer = "ASUS";
            int countManufacturer = laptops.Count(l => l.Manufacturer.Equals(targetManufacturer, StringComparison.OrdinalIgnoreCase));
            WriteLine($"laptops from {targetManufacturer}: {countManufacturer}");
            var minPriceLaptop = laptops.MinBy(l => l.Price);
            WriteLine($"Laptop with min price: {minPriceLaptop}");
            var maxPriceLaptop = laptops.MaxBy(l => l.Price);
            WriteLine($"laptops with max price: {maxPriceLaptop}");
            var minFreqLaptop = laptops.MinBy(l => l.Processor);
            WriteLine($"laptops with min processor frequency: {minFreqLaptop}");
            var newLaptop = laptops.MaxBy(l => l.Year);
            WriteLine($"new laptop model: {newLaptop}");
            double avgPrice = laptops.Average(l => l.Price);
            WriteLine($"average laptop price: {avgPrice:F2}");
            WriteLine();
            WriteLine();
            WriteLine("STATISTICS");
            WriteLine("laptops count by manufacturer:");
            laptops.GroupBy(l => l.Manufacturer)
                   .Select(g => new { Manufacturer = g.Key, Count = g.Count() })
                   .ToList()
                   .ForEach(item => WriteLine($"{item.Manufacturer}: {item.Count} laptops"));
            WriteLine("laptops count by model:");
            laptops.GroupBy(l => l.Model)
                   .Select(g => new { Model = g.Key, Count = g.Count() })
                   .ToList()
                   .ForEach(item => WriteLine($"{item.Model}: {item.Count}"));
            WriteLine("laptops statistics by years:");
            laptops.GroupBy(l => l.Year)
                   .Select(g => new { Year = g.Key, Count = g.Count() })
                   .OrderBy(g => g.Year)
                   .ToList()
                   .ForEach(item => WriteLine($"Year {item.Year}: {item.Count} laptops"));
            WriteLine();
            WriteLine("top 5 most expensive:");
            laptops.OrderBy(l => l.Price)
                   .Skip(laptops.Count() - 5)
                   .ToList()
                   .ForEach(l => WriteLine($"{l.Model} - {l.Price}"));
            WriteLine("top 5 cheapest:");
            laptops.OrderBy(l => l.Price)
                   .Take(5)
                   .ToList()
                   .ForEach(l => WriteLine($"{l.Model} - {l.Price}"));
            WriteLine("top 3 oldest:");
            laptops.OrderBy(l => l.Year)
                   .Take(3)
                   .ToList()
                   .ForEach(l => WriteLine($"{l.Model} ({l.Year})"));
            WriteLine("top 3 newest:");
            laptops.OrderBy(l => l.Year)
                   .Skip(laptops.Count() - 3)
                   .ToList()
                   .ForEach(l => WriteLine($"{l.Model} ({l.Year})"));



            //завдання5
            string[] surnames = { "Blue", "Watson", "White", "Orange", "Leede", "Willows", "Johan" };
            WriteLine("All surnames: " + string.Join(", ", surnames));
            WriteLine();
            bool allLengthGreaterThan3 = surnames.All(s => s.Length > 3);
            WriteLine($"All surnames have length > 3: {allLengthGreaterThan3}");
            bool allLengthBetween3And10 = surnames.All(s => s.Length > 3 && s.Length < 10);
            WriteLine($"All surnames have length > 3 and < 10: {allLengthBetween3And10}");
            bool anyStartsWithW = surnames.Any(s => s.StartsWith("W", StringComparison.OrdinalIgnoreCase));
            WriteLine($"Surname starts with W: {anyStartsWithW}");
            bool anyEndsWithY = surnames.Any(s => s.EndsWith("y", StringComparison.OrdinalIgnoreCase));
            WriteLine($"Surname ends with Y: {anyEndsWithY}");
            bool containsOrange = surnames.Contains("Orange");
            WriteLine($"Array contains Orange: {containsOrange}");
            string firstLength6 = surnames.FirstOrDefault(s => s.Length == 6);
            WriteLine($"Surname with length 6: {firstLength6 ?? "Not found"}");
            string lastLengthLess15 = surnames.LastOrDefault(s => s.Length < 15);
            WriteLine($"Surname with length < 15: {lastLengthLess15 ?? "Not found"}");



            //завдання6
            List<Magazine> magazines = new List<Magazine>
            {
            new Magazine("Vogue", "Fashion", 45, 2026),
            new Magazine("Forbes", "Politics", 60, 2022),
            new Magazine("Auto World", "Auto", 35, 2026),
            new Magazine("Sport Express", "Sport", 40, 2024),
            new Magazine("Garden Life", "Garden", 50, 2021)
            };
            WriteLine("ALL MAGAZINES");
            magazines.ForEach(m => WriteLine(m));
            WriteLine();
            bool allPagesMore30 = magazines.All(m => m.PagesCount > 30);
            WriteLine($"magazines have pages > 30: {allPagesMore30}");
            string[] allGenres = { "Politics", "Fashion", "Sport" };
            bool allInGenres = magazines.All(m => allGenres.Contains(m.Genre, StringComparer.OrdinalIgnoreCase));
            WriteLine($"magazines in Politics, Fashion, or Sport genres: {allInGenres}");
            bool anyGarden = magazines.Any(m => m.Genre.Equals("Garden", StringComparison.OrdinalIgnoreCase));
            WriteLine($"magazine in Garden: {anyGarden}");
            bool anyFishing = magazines.Any(m => m.Genre.Equals("Fishing", StringComparison.OrdinalIgnoreCase));
            WriteLine($"magazine in Fishing: {anyFishing}");
            bool containsHunting = magazines.Select(m => m.Genre).Contains("Hunting", StringComparer.OrdinalIgnoreCase);
            WriteLine($"magazines contain Hunting: {containsHunting}");
            var first2022 = magazines.FirstOrDefault(m => m.Year == 2022);
            WriteLine($"magazine with year 2022: {first2022?.ToString() ?? "Not found"}");
            var lastAuto = magazines.LastOrDefault(m => m.Title.StartsWith("Auto", StringComparison.OrdinalIgnoreCase));
            WriteLine($"magazine starting with Auto: {lastAuto?.ToString() ?? "Not found"}");
        }
    }
}
