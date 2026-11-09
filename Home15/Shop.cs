using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Home15GC
{
    public enum ShopType
    {
        General,
        Grocery,     
        Household,   
        Clothing,    
        Footwear    
    }
    public class Shop : IDisposable
    {
        private static int totalShopsCreated = 0;
        public string Name { get; init; } = "Unknown";
        public string Address { get; set; } = "Unknown";
        public ShopType Type { get; set; } = ShopType.General;
        private bool isDisposed = false;
        public Shop()
        {
            totalShopsCreated++;
        }
        public Shop(string name, string address, ShopType type)
        {
            Name = name;
            Address = address;
            Type = type;
            totalShopsCreated++;
            WriteLine($"Constructor: Shop {Name} has been created");
        }
        public static int TotalShopsCreated
        {
            get { return totalShopsCreated; }
        }
        public void Display()
        {
            if (isDisposed)
                throw new ObjectDisposedException(Name, "The object has already been disposed");

            WriteLine($"Shop: {Name} Address: {Address} Type: {Type}");
        }
        public void Dispose()
        {
            _Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void _Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    WriteLine($"Dispose: Managed resources explicitly cleaned for shop {Name}");
                }
                isDisposed = true;
            }
        }
        ~Shop()
        {
            --totalShopsCreated;
            _Dispose(false);
            WriteLine($"Destructor / Finalizer: Garbage Collector removed shop {Name} because Dispose() was not called");
        }
    }
}
