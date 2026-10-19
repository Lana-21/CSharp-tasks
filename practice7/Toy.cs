using System;

namespace StoreApp
{
    public class Toy : Product
    {
        public int AgeCategory { get; set; }
        public string ManufacturePlace { get; set; }
        public Toy() : base()
        {
            AgeCategory = 1;
            ManufacturePlace = "Ukraine";
        }
        public Toy(string name, string location, double price, int ageCategory, string manufacturePlace)
            : base(name, location, price)
        {
            AgeCategory = ageCategory;
            ManufacturePlace = manufacturePlace;
        }
        override public void Passport()
        {
            Console.WriteLine($"Toy: {Name}\n Location: {Location}\n Price: {Price} UAH\n Age: {AgeCategory}+ \n Made in: {ManufacturePlace}");
        }
        public override string ToString()
        {
            return base.ToString() + $", Age: {AgeCategory}+, Made in: {ManufacturePlace}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || (obj is Toy) == false)
            {
                return false;
            }
            Toy toy = obj as Toy;
            return GetHashCode() == toy.GetHashCode();
        }
    }
}
