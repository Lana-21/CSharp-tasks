using System;
using System.Collections.Generic;
using System.Text;

namespace Home5
{ //завдання1
    enum ItemCategory
    {
        Consumable,
        Weapon,
        Armor
    }
    struct Item
    {
        public string Name;
        public double Price;
        public int Quantity;
        public ItemCategory Category;
        public int PowerBonus;

        public Item(string name, double price, int quantity, ItemCategory category, int powerBonus)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Error: Item name cannot be empty or null!");
            }
            if (price < 0 || quantity < 0)
            {
                throw new ArgumentException("Error: Price or Quantity cannot be negative");
            }
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            PowerBonus = powerBonus;
        }
        public override string ToString()
        {
            return $"{Category} {Name} \n Price: {Price} \n Quantity: {Quantity} \n Bonus: +{PowerBonus}";
        }
    }
    class GameStore
    {
        private Item[] items = new Item[0];
        public void AddItem(Item newItem)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = newItem;
            Console.WriteLine($"Item {newItem.Name} has been added to the store");
        }
        public void RemoveItem(string itemName)
        {
            int index = -1;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name.ToLower() == itemName.ToLower())
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                for (int i = index; i < items.Length - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                Array.Resize(ref items, items.Length - 1); 
                Console.WriteLine($"Item {itemName} has been removed from the store.");
            }
            else throw new ArgumentException($"Error: Item {itemName} not found in the store");
        }
        public void UpdateItem(string itemName, double newPrice, int newQuantity)
        {
            if (newPrice < 0 || newQuantity < 0)
            {
                throw new ArgumentException("Error: Price and quantity cannot be negative");
            }
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name.ToLower() == itemName.ToLower())
                {
                    items[i].Price = newPrice;
                    items[i].Quantity = newQuantity;
                    Console.WriteLine($"Item {itemName} has been successfully updated");
                    return;
                }
            }
            throw new ArgumentException($"Error: Item {itemName} not found for update");
        }
        public void ShowCatalog()
        {
            Console.WriteLine("\nGAME STORE CATALOG");
            if (items.Length == 0) Console.WriteLine("The store is currently empty");
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }
    }


    //завдання2
    //enum TaskStatus
    //{
    //    NotStarted,
    //    InProgress,
    //    Completed,
    //    Deferred
    //}
    //class Task
    //{
    //    private string name;
    //    public string Description { get; set; }
    //    public TaskStatus Status { get; set; }
    //    public Task(string name, string description, TaskStatus status)
    //    {
    //        Name = name;
    //        Description = description;
    //        Status = status;
    //    }
    //    public string Name
    //    {
    //        get { return name; }
    //        set
    //        {
    //            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Task name cannot be empty");
    //            name = value;
    //        }
    //    }    
    //    public override string ToString()
    //    {
    //        return $"Status: {Status} \n {Name} \n Description: {Description}";
    //    }
    //}
    //class TodoList
    //{
    //    private Task[] tasks = new Task[0];
    //    public void AddTask(Task newTask)
    //    {
    //        Array.Resize(ref tasks, tasks.Length + 1);
    //        tasks[tasks.Length - 1] = newTask;
    //        Console.WriteLine($"Task {newTask.Name} has been added");
    //    }
    //    public void RemoveTask(string taskName)
    //    {
    //        int index = -1;
    //        for (int i = 0; i < tasks.Length; i++)
    //        {
    //            if (tasks[i].Name.ToLower() == taskName.ToLower())
    //            {
    //                index = i;
    //                break;
    //            }
    //        }
    //        if (index != -1)
    //        {
    //            for (int i = index; i < tasks.Length - 1; i++)
    //            {
    //                tasks[i] = tasks[i + 1];
    //            }
    //            Array.Resize(ref tasks, tasks.Length - 1);
    //            Console.WriteLine($"Task {taskName} has been removed");
    //        }
    //        else throw new ArgumentException($"Error: Task {taskName} not found");
    //    }
    //    public void UpdateTaskStatus(string taskName, TaskStatus newStatus)
    //    {
    //        for (int i = 0; i < tasks.Length; i++)
    //        {
    //            if (tasks[i].Name.ToLower() == taskName.ToLower())
    //            {
    //                tasks[i].Status = newStatus;
    //                Console.WriteLine($"Task {taskName} status updated to {newStatus}");
    //                return;
    //            }
    //        }
    //        throw new ArgumentException($"Error: Task {taskName} not found for status update");
    //    }
    //    public void ShowAllTasks()
    //    {
    //        Console.WriteLine("\nALL TASKS");
    //        if (tasks.Length == 0) Console.WriteLine("No tasks available");
    //        else
    //        {
    //            foreach (var task in tasks)
    //            {
    //                Console.WriteLine(task);
    //            }
    //        }
    //        Console.WriteLine();
    //    }
    //    public void ShowTasksByStatus(TaskStatus targetStatus)
    //    {
    //        Console.WriteLine($"\nTASKS WITH STATUS: {targetStatus}");
    //        bool found = false;
    //        foreach (var task in tasks)
    //        {
    //            if (task.Status == targetStatus)
    //            {
    //                Console.WriteLine(task);
    //                found = true;
    //            }
    //        }
    //        if (!found) Console.WriteLine($"No tasks found with status {targetStatus}");
    //        Console.WriteLine();
    //    }
    //}
}
