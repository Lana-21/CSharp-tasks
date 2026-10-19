using System;

namespace StoreApp
{
    public class Product
    {
        public string Name { get; set; }= "Unknown";
        public string Location { get; set; } = "Unknown";
        public double Price { get; set; }
        public Product() {}
        public Product(string name, string location, double price)
        {
            Name = name;
            Location = location;
            Price = price;
        }
        virtual public void Passport()
        {
            Console.WriteLine($"Product: {Name}\n Location: {Location}\n Price: {Price} UAH");
        }
        public override string ToString()
        {
            return $"Name = {Name}, Location = {Location}, Price = {Price}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || (obj is Product) == false)
            {
                return false;
            }
            Product product = obj as Product;
            return GetHashCode() == product.GetHashCode();
        }
    }
}
