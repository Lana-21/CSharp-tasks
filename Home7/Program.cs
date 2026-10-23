using static System.Console;
namespace Home7
{
    internal class Program
    {
        //завдання1
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        Product product = new Product("Laptop", 1200, 50);
        //        product.Display();
        //        product.DecreasePrice(100, 25);
        //        Console.WriteLine(product.ToString());
        //        Product product2 = new Product("Laptop", 1100, 25);
        //        Console.WriteLine("Are products equal: " + product.Equals(product2));
        //    }
        //    catch (ArgumentException my)
        //    {
        //        WriteLine("Argument Error: " + my.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}



        //завдання2
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        Device[] devices = new Device[]
        //        {
        //            new Kettle("Kettle", "1.5L, 2000W"),
        //            new Microwave("Samsung Microwave", "1000W, grill"),
        //            new Car("Opel", "Electric, autopilot"),
        //            new Steamship("Steamship", "Steam engine, 400 passengers")
        //        };
        //        foreach (Device dev in devices)
        //        {
        //            Console.WriteLine();
        //            dev.Show();
        //            dev.Desc();
        //            dev.Sound();
        //            Console.WriteLine(dev.ToString());
        //        }
        //        Kettle kettle1 = new Kettle("Kettle", "1.8L, 2000W");
        //        Kettle kettle2 = new Kettle("Kettle", "1.5L, 2000W");
        //        Console.WriteLine();
        //        Console.WriteLine("Are the kettles equal: " + kettle1.Equals(kettle2));
        //    }
        //    catch (ArgumentException my)
        //    {
        //        WriteLine("Argument Error: " + my.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}



        //завдання3
        static void Main(string[] args)
        {
            try
            {
                Course[] courses = new Course[]
                {
                    new Course("History", 40),
                    new OnlineCourse("C# Development", 60, "Online"),
                    new OnlineCourse("Web Design", 30, "Course")
                };
                Console.WriteLine("AllCourses");
                foreach (Course c in courses)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine("\nOnline Courses");
                foreach (Course c in courses)
                {
                    if (c is OnlineCourse)
                    {
                        OnlineCourse oc = c as OnlineCourse;
                        Console.WriteLine(oc.ToString());
                    }
                }
                OnlineCourse oc1 = new OnlineCourse("C# Development", 60, "Online");
                OnlineCourse oc2 = new OnlineCourse("C# Development", 60, "Online");
                Console.WriteLine("\nEquals Testing");
                Console.WriteLine("Are courses equal: " + oc1.Equals(oc2));
            }
            catch (ArgumentException my)
            {
                WriteLine("Argument Error: " + my.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
