using static System.Console;
namespace Home5
{
    internal class Program
    {
        //завдання1
        static void Main(string[] args)
        {
            GameStore store;
            try
            {
                store = new GameStore();
                Item hpPotion = new Item("Health Health", 60, 30, ItemCategory.Consumable, 30);
                store.AddItem(hpPotion);
                store.ShowCatalog();
                store.UpdateItem("Health Health", 45, 15);
                store.RemoveItem("NonItem");
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


        //завдання2
        //static void Main(string[] args)
        //{
        //    TodoList myTodoList;
        //    try
        //    {
        //        myTodoList = new TodoList();
        //        Task task1 = new Task("Homework", "Complete the struct and classes tasks", TaskStatus.InProgress);
        //        Task task2 = new Task("Buy products", "Milk, bread, eggs", TaskStatus.NotStarted);
        //        Task task3 = new Task("Clean room", "Vacuum and tidy up", TaskStatus.Deferred);
        //        myTodoList.AddTask(task1);
        //        myTodoList.AddTask(task2);
        //        myTodoList.AddTask(task3);
        //        myTodoList.ShowAllTasks();
        //        myTodoList.UpdateTaskStatus("Buy products", TaskStatus.Completed);
        //        myTodoList.UpdateTaskStatus("Homework", TaskStatus.Completed);
        //        myTodoList.ShowTasksByStatus(TaskStatus.Completed);
        //        myTodoList.RemoveTask("Clean room");
        //        myTodoList.ShowAllTasks();
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
