
using static System.Console;
namespace Practice6Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1;
            Employee emp2;
            try
            {
                emp1 = new Employee("Oles Oles", new DateTime(2002, 4, 22), "+3805012341237", "oles@company.com", "Developer", "Coding", 50000);
                emp2 = new Employee("Vasyl Vasyl", new DateTime(2001, 6, 12), "+380671231234", "vasyl@company.com", "Manager", "Management", 55000);
                WriteLine(emp1);
                WriteLine(emp2);
                WriteLine("Comparison Operators");
                WriteLine($"emp1 == emp2: {emp1 == emp2}");
                WriteLine($"emp1 != emp2: {emp1 != emp2}");
                WriteLine($"emp1 > emp2: {emp1 > emp2}");
                WriteLine($"emp1 < emp2: {emp1 < emp2}");
                WriteLine($"emp1.Equals(emp2): {emp1.Equals(emp2)}");
                WriteLine("Modifying Salary Using + - ");
                emp1 = emp1 + 100; 
                WriteLine($"emp1 salary after adding 100: {emp1.Salary}");
                emp2 = emp2 - 100;
                WriteLine($"emp2 salary after subtracting 100: {emp2.Salary}");
            }
            catch (FormatException my)
            {
                WriteLine("Format Error: " + my.Message);
            }
            catch (ArgumentException my)
            {
                WriteLine("Argument Error: " + my.Message);
            }
            catch (OverflowException my)
            {
                WriteLine("Overflow Error: " + my.Message);
            }
            catch (Exception my)
            {
                WriteLine("Error: " + my.Message);
            }
            WriteLine("\nPress any key to exit ");
            ReadKey();
        }
      
        //static void Main(string[] args)
        //{
        //    CreditCard card1;
        //    CreditCard card2;
        //    try
        //    {
        //        card1 = new CreditCard("4532015112830366", "Oles Oles", "123", DateTime.Now.AddYears(2), 1500.0);
        //        card2 = new CreditCard("4532015112830366", "Vasyl Vasyl", "123", DateTime.Now.AddYears(1), 3000.0); 
        //        WriteLine(card1);
        //        WriteLine(card2);
        //        WriteLine("Comparison Operators:");
        //        WriteLine($"card1 == card2 : {card1 == card2}");
        //        WriteLine($"card1 != card2: {card1 != card2}");
        //        WriteLine($"card1 > card2: {card1 > card2}");
        //        WriteLine($"card1 < card2: {card1 < card2}");
        //        WriteLine($"card1.Equals(card2): {card1.Equals(card2)}");
        //        WriteLine("Modifying Balance Using + and - :");
        //        card1 = card1 + 100;
        //        WriteLine($"Card 1 balance after adding 100: {card1.Balance}");
        //        card2 = card2 - 100;
        //        WriteLine($"Card 2 balance after subtracting 100: {card2.Balance}");
        //    }
        //    catch (FormatException my)
        //    {
        //        WriteLine("Format Error: " + my.Message);
        //    }
        //    catch (ArgumentException my)
        //    {
        //        WriteLine("Argument Error: " + my.Message);
        //    }
        //    catch (OverflowException my)
        //    {
        //        WriteLine("Overflow Error: " + my.Message);
        //    }
        //    catch (Exception my)
        //    {
        //        WriteLine("Error: " + my.Message);
        //    }
        //    WriteLine("\nPress any key to exit ");
        //    ReadKey();
        //}
    }
}

