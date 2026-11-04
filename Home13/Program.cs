using System;
using System.Linq;
using static System.Console;
namespace Practice13LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            int[] numbers = { 5, 7, 8, 10, 14, 16, 21, 24, 25, 28, 32, 35, 40, 42, 48, 49, 50 };
            WriteLine("numbers: ");
            numbers
                .ToList()
                .ForEach(n => WriteLine(n));
            WriteLine("\nEven");
            numbers
                .Where(n => n % 2 == 0)
                .ToList()
                .ForEach(n => WriteLine(n));
            WriteLine("\nOdd");
            var numbs = numbers
                .Where(n => n % 2 != 0)
                .ToList();
            numbs
           .ForEach(n => WriteLine(n));
            int min = 10, max = 20;
            WriteLine($"\nNumbers in range {min}-{max}");
            numbers
                .Where(n => n >= min && n <= max)
                .ToList()
                .ForEach(n => WriteLine(n));
            WriteLine("\nDivide by 7");
            numbers
                .Where(n => n % 7 == 0)
                .OrderBy(n => n)
                .ToList()
                .ForEach(n => WriteLine(n));
            WriteLine("\nDivide by 8");
            numbers
                .Where(n => n % 8 == 0)
                .OrderByDescending(n => n)
                .ToList()
                .ForEach(n => WriteLine(n));

            //завдання2
            string[] cities = {
                "Kyiv",
                "Amsterdam",
                "Athens",
                "Rome",
                "Jerusalem",
                "Newark",
                "Madrid",
                "London"
            };
            WriteLine("cities");
            var allCities = cities
                .ToList();
            allCities
                .ForEach(c => WriteLine(c));
            int myLength = 4;
            WriteLine($"\nCities with name length {myLength}");
            var citiesByLength = cities
            .Where(c => c.Length == myLength)
            .ToList();
            citiesByLength
                .ForEach(c => WriteLine(c));
            WriteLine("\nCities with A");
            var citiesStartWithA = cities
                .Where(c => c.ToUpper().StartsWith("A"))
                .ToList();
            citiesStartWithA
                .ForEach(c => WriteLine(c));
            WriteLine("\nCities with M");
            var citiesEndWithM = cities
                .Where(c => c.ToUpper().EndsWith("M"))
                .ToList();
            citiesEndWithM
                .ForEach(c => WriteLine(c));
            WriteLine("\nCities starting with N and ending with K");
            var citiesStartNEndK = cities
                .Where(c => c.ToUpper().StartsWith("N") && c.ToUpper().EndsWith("K"))
                .ToList();
            citiesStartNEndK
                .ForEach(c => WriteLine(c));



            //завдання3
            Student[] students = {
            new Student("John", "Brown", 20, "KNU"),
            new Student("Alice", "Brothers", 22, "KPI"),
            new Student("Bob", "Smith", 19, "KNU"),
            new Student("Charlie", "Bronco", 24, "LNU"),
            new Student("Diana", "Adams", 21, "KNU"),
            new Student("Eve", "Taylor", 18, "NaUKMA")
            };
            WriteLine("All students");
            var allStudents = students.ToList();
            allStudents
                .ForEach(s => WriteLine(s));
            WriteLine("\nStudents with Bro");
            var studentsBro = students
                .Where(s => s.LastName.ToUpper().StartsWith("BRO"))
                .ToList();
            studentsBro
                .ForEach(s => WriteLine(s));
            WriteLine("\nStudents older 19");
            var studentsOlder19 = students
                .Where(s => s.Age > 19)
                .ToList();
            studentsOlder19
                .ForEach(s => WriteLine(s));
            WriteLine("\nStudents older 20 and younger 23");
            var studentsBetween20And23 = students
                .Where(s => s.Age > 20 && s.Age < 23)
                .ToList();
            studentsBetween20And23
                .ForEach(s => WriteLine(s));
            WriteLine("\nKNU students older than 18");
            var knuStudents = students
                .Where(s => s.University.ToUpper() == "KNU" && s.Age > 18)
                .OrderByDescending(s => s.Age)
                .ToList();
            knuStudents
                .ForEach(s => WriteLine(s));


            //завдання4
            //Firm[] firms = {
            //    new Firm("Tech Food Innovations", new DateTime(2010, 5, 1), "IT", "Ivan Ivanov", 500, "Kyiv, Ukraine"),
            //    new Firm("Quick Food Solutions", DateTime.Now.AddYears(-3), "Logistics", "Petro Petrov", 150, "Lviv, Ukraine"),
            //    new Firm("Creative Marketing Agency", new DateTime(2018, 10, 15), "Marketing", "Oleksandr Syd", 80, "London, UK"),
            //    new Firm("Food Basket LLC", new DateTime(2020, 1, 1), "Retail", "Maria Koval", 200, "Berlin, Germany"),
            //    new Firm("Alpha IT Corp", new DateTime(2015, 3, 20), "IT", "Vasyl Kot", 120, "London, UK"),
            //    new Firm("Beta Marketing Group", DateTime.Now.Date.AddDays(-123), "Marketing", "John White", 95, "Paris, France"),
            //    new Firm("Consulting Solutions", new DateTime(1995, 8, 30), "Consulting", "Olena Uayt", 250, "Madrid, Spain"),
            //    new Firm("AgroFood Tech", DateTime.Now.AddYears(-1), "AgroIT", "Hanna Povar", 180, "Kyiv, Ukraine"),
            //    new Firm("White Star Real Estate", new DateTime(2012, 11, 11), "Real Estate", "Henry Black", 130, "London, UK"),
            //    new Firm("Gamma Food Services", new DateTime(1990, 1, 1), "Logistics", "Andrii Moroz", 310, "Lviv, Ukraine")
            //};
            //WriteLine("1All firms");
            //var allFirms = firms
            //    .ToList();
            //allFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("2Firms with the word Food");
            //var foodFirms = firms
            //    .Where(f => f.Name.Contains("Food"))
            //    .ToList();
            //foodFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("3Firms marketing");
            //var marketingFirms = firms
            //    .Where(f => f.BusinessProfile.Contains("Marketing"))
            //    .ToList();
            //marketingFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("4Firms marketing or IT");
            //var marketingOrItFirms = firms
            //    .Where(f => f.BusinessProfile.Contains("Marketing") || f.BusinessProfile.Contains("IT"))
            //    .ToList();
            //marketingOrItFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("5Firms 100 employees");
            //var moreThan100Employees = firms
            //    .Where(f => f.EmployeeCount > 100)
            //    .ToList();
            //moreThan100Employees
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("6Firms between 100 and 300");
            //var employeesInRange = firms
            //    .Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300)
            //    .ToList();
            //employeesInRange
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("7Firms in London");
            //var londonFirms = firms
            //    .Where(f => f.Address.Contains("London"))
            //    .ToList();
            //londonFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("8Firms with director White");
            //var whiteDirectorFirms = firms
            //    .Where(f => f.DirectorFullName.ToUpper().Contains("WHITE"))
            //    .ToList();
            //whiteDirectorFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("9Firms two years ago");
            //var twoYearsAgo = DateTime.Now.AddYears(-2);
            //var oldFirms = firms
            //    .Where(f => f.FoundingDate < twoYearsAgo)
            //    .ToList();
            //oldFirms
            //    .ForEach(f => WriteLine(f));
            //WriteLine();
            //WriteLine("10Firms founded 123");
            //var daysAgo123 = DateTime.Now.Date.AddDays(-123);
            //var firms123DaysOld = firms
            //    .Where(f => f.FoundingDate.Date == daysAgo123)
            //    .ToList();
            //firms123DaysOld
            //    .ForEach(f => WriteLine(f));
            //WriteLine();



            //завдання5
            //static int GetSum(int n)
            //{
            //    return n.ToString().Sum(c => c - '0');
            //}
            //static void Main()
            //{
            //    int[] numbers = { 121, 75, 81 };
            //    WriteLine("Original Array");
            //    var allNumbers=numbers
            //        .ToList();
            //    allNumbers
            //        .ForEach(n => WriteLine($"{n}(sum: {GetSum(n)}"));
            //    WriteLine("\nSorting by sum (increase)");
            //    var sortIncrease = numbers
            //        .OrderBy(n => GetSum(n))
            //        .ToList();
            //    sortIncrease
            //        .ForEach(n => WriteLine($"{n} (sum: {GetSum(n)})"));
            //    WriteLine("\nSorting by sum (decrease)");
            //    var sortdDecrease = numbers
            //         .OrderByDescending(n => GetSum(n))
            //         .ToList();
            //    sortdDecrease
            //         .ForEach(n => WriteLine($"{n} (sum: {GetSum(n)})"));
            //}



            //завдання6
            int[] array1 = { 1, 2, 3, 4, 5, 2 };
            int[] array2 = { 4, 5, 6, 7, 8 };
            WriteLine("difference");
            var difference = array1
                    .Except(array2)
                    .ToList();
            difference
                    .ForEach(n => WriteLine(n));
            WriteLine("intersect");
            var intersect = array1
                    .Intersect(array2)
                    .ToList();
            intersect
                    .ForEach(n => WriteLine(n));
            WriteLine("union");
            var union = array1
                    .Union(array2)
                    .ToList();
            union
                    .ForEach(n => WriteLine(n));
            WriteLine("distinctFirst");
            var distinctFirst = array1
                    .Distinct()
                    .ToList();
            distinctFirst
                    .ForEach(n => WriteLine(n));




            //завдання7
            Firm[] firms = {
                new Firm("Tech Food Innovations", new DateTime(2010, 5, 1), "IT", "Ivan Ivanov", 500, "Kyiv, Ukraine", new List<Employee> {
                    new Employee("Lionel Messi", "Manager", "2334455", "lionel.manager@tech.com", 1500),
                    new Employee("Anna Smith", "Developer", "4455667", "anna.dev@tech.com", 1200),
                    new Employee("Diana Prince", "Manager", "2399887", "di.prince@tech.com", 1600)
                }),
                new Firm("Quick Food Solutions", DateTime.Now.AddYears(-3), "Logistics", "Petro Petrov", 150, "Lviv, Ukraine", new List<Employee> {
                    new Employee("Oleh Vynnyk", "Driver", "5544332", "oleh@quick.com", 800),
                    new Employee("Diego Maradona", "Manager", "2311223", "diego.m@quick.com", 1400)
                }),
                new Firm("Creative Marketing Agency", new DateTime(2018, 10, 15), "Marketing", "Oleksandr Syd", 80, "London, UK", new List<Employee> {
                    new Employee("John Doe", "Designer", "7788990", "john.d@Creative.com", 1100)
                }),
                new Firm("Food Basket LLC", new DateTime(2020, 1, 1), "Retail", "Maria Koval", 200, "Berlin, Germany", new List<Employee> {
                    new Employee("Lionel Richie", "Director", "9988776", "lionel.r@basket.com", 2500),
                    new Employee("Dinara Karimova", "Manager", "2300001", "dinara.k@basket.com", 1350)
                })
            };
            WriteLine("All employees");      
            string targetFirm = "Tech Food Innovations";
            var firmEmployees = firms
                .Where(f => f.Name == targetFirm)
                .SelectMany(f => f.Employees)
                .ToList();
            firmEmployees
                .ForEach(e => WriteLine(e));
            WriteLine("Employees with salary > 1300");
            double minSalary = 1300;
            var highPaidEmployees = firms
                .Where(f => f.Name == targetFirm)
                .SelectMany(f => f.Employees)
                .Where(e => e.Salary > minSalary)
                .ToList();
            highPaidEmployees
                .ForEach(e => WriteLine(e));
            WriteLine("Employees of all firms with position Manager");
            var managers = firms
                .SelectMany(f => f.Employees) 
                .Where(e => e.Position == "Manager")
                .ToList();
            managers
                .ForEach(e => WriteLine(e));
            WriteLine("Employees whose phone starts with 23");
            var phoneStartsWith23 = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Phone.StartsWith("23"))
                .ToList();
            phoneStartsWith23
                .ForEach(e => WriteLine(e));
            WriteLine("Employees whose Email starts with di");
            var emailStartsWithDi = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Email.ToLower().StartsWith("di"))
                .ToList();
            emailStartsWithDi
                .ForEach(e => WriteLine(e));
            WriteLine("Employees named Lionel");
            var lionelEmployees = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.FullName.Contains("Lionel"))
                .ToList();
            lionelEmployees
                .ForEach(e => WriteLine(e));
            ReadLine();
        }
    }
}
