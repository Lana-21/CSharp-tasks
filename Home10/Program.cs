using static System.Console;
namespace Home10EVENT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    //завдання1
            //    DailyTemperature[] weekTemperatures = new DailyTemperature[]
            //    {
            //        new DailyTemperature(20.5, 10.0),
            //        new DailyTemperature(25.0, 12.0),
            //        new DailyTemperature(18.0, 15.0),
            //        new DailyTemperature(22.5, 7.0)
            //    };
            //    WriteLine("Daily Temperatures");
            //    foreach (var t in weekTemperatures)
            //    {
            //        WriteLine($"Max: {t.MaxTemp}, Min: {t.MinTemp} (Difference: {t.MaxTemp - t.MinTemp})");
            //    }
            //    DailyTemperature result = weekTemperatures.GetDayWithMaxDifference();
            //    WriteLine("\nResult");
            //    if (result != null)
            //    {
            //        WriteLine($"Day with the maximum difference:");
            //        WriteLine($"Highest: {result.MaxTemp}°C, Lowest: {result.MinTemp}°C");
            //        WriteLine($"Difference is: {result.MaxTemp - result.MinTemp}°C");
            //    }
            //    ReadKey();




            //завдання2
            //StudentGrades[] students = new StudentGrades[]
            //{
            //    new StudentGrades("Oleksandr Petrenko", new double[] { 85, 90, 78 }),
            //    new StudentGrades("Maria Kovalenko", new double[] { 95, 92, 96 }),
            //    new StudentGrades("Ivan Shevchenko", new double[] { 70, 75, 80 })
            //};
            //WriteLine("Students List");
            //foreach (var s in students)
            //{
            //    double avg = Student.CalculateAverage(s.Grades);
            //    WriteLine($"{s.FullName} Average: {avg}");
            //}
            //StudentGrades topStudent = Student.GetStudentWithMaxAverage(students);
            //WriteLine("\nTop Student");
            //if (topStudent != null)
            //{
            //    double topAvg = Student.CalculateAverage(topStudent.Grades);
            //    WriteLine($"Best: {topStudent.FullName} {topAvg}");
            //}
            //ReadKey();



            //завдання3
            //Func<DateTime, bool> isProgrammerDay = date => date.DayOfYear == 256;
            //DateTime test1 = new DateTime(2026, 9, 13);
            //DateTime test2 = new DateTime(2026, 1, 1);
            //DateTime test3 = new DateTime(2021, 9, 12);
            //WriteLine("Programmer's Day");
            //WriteLine($"Date {test1}: {isProgrammerDay(test1)}");
            //WriteLine($"Date {test2}: {isProgrammerDay(test2)}");
            //WriteLine($"Date {test3}: {isProgrammerDay(test3)}");
            //ReadKey();


            //завдання4
            CreditCard myCard = new CreditCard(
                 "4149-5123-4567-8900",
                 "Oleksandr Petrenko",
                 "12/28",
                 "1234",
                 5000,
                 2000,
                 10000
             );
            myCard.TopUpEvent += msg => WriteLine($"EVENT - TopUp: {msg}");
            myCard.WithdrawEvent += msg => WriteLine($"EVENT - Withdraw: {msg}");
            myCard.CreditStartedEvent += msg => WriteLine($"EVENT - Credit: {msg}");
            myCard.TargetAmountReachedEvent += msg => WriteLine($"EVENT - Target Limit: {msg}");
            myCard.PinChangedEvent += msg => WriteLine($"EVENT - PIN: {msg}");
            try
            {
                WriteLine($"Card created. Owner: {myCard.OwnerFullName}, Balance: {myCard.Balance}\n");
                myCard.ChangePin("1234", "5678");
                WriteLine();
                myCard.Withdraw(1500, "5678");
                WriteLine();
                myCard.Withdraw(1000, "5678");
                WriteLine();
                myCard.TopUp(11000);
            }
            catch (ArgumentException ex)
            {
                WriteLine($"ARGUMENT EXCEPTION: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                WriteLine($"INVALID OPERATION EXCEPTION: {ex.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"ERROR: {ex.Message}");
            }
            ReadKey();
        }
    }  
}
