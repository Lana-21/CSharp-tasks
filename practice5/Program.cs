using static System.Console;

namespace Practice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Birthday myBirthday;
            try
            {
                WriteLine("BIRTHDAY STRUCTURE");
                myBirthday = new Birthday(2005, 4, 1);
                WriteLine(myBirthday.ToString());
                int targetYear = 2026;
                WriteLine($"In {targetYear}, the birthday will be on: {myBirthday.GetDayOfWeekInYear(targetYear)}");
                int daysLeft = myBirthday.GetDaysUntilNextBirthday();
                WriteLine($"Days remaining until the next birthday: {daysLeft}");
            }
            catch (ArgumentException my)
            {
                WriteLine("Argument Error: " + my.Message);
            }
            catch (FormatException my)
            {
                WriteLine("Format Error: " + my.Message);
            }
            catch (Exception my)
            {
                WriteLine("Error: " + my.Message);
            }
            WriteLine("\nPress any key to exit");
            ReadKey();
        }
    }
}
