using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Product : Money
    {
        private string name;

        public Product() : base()
        {
            Name = "Unknown";
        }
        public Product(string name, int wholePart, int coinPart) : base(wholePart, coinPart)
        {
            Name = name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be empty!");
                }
                name = value;
            }
        }
        public void DecreasePrice(int wholePart, int coinPart)
        {
            if (wholePart < 0 || coinPart < 0)
            {
                throw new ArgumentException("Decrease values cannot be negative");
            }
            int totalCurrentCents = WholePart * 100 + CoinPart;
            int totalDecreaseCents = wholePart * 100 + coinPart;
            int resultCents = totalCurrentCents - totalDecreaseCents;
            if (resultCents < 0)
            {
                throw new ArgumentException("Product price cannot become negative");
            }
            WholePart = resultCents / 100;
            CoinPart = resultCents % 100;
        }
        public override string ToString()
        {
            return "Product: " + Name + ", Price: " + WholePart + "." + CoinPart;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
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
