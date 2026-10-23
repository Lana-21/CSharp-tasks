using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Steamship : Device
    {
        public Steamship() : base() {}
        public Steamship(string name, string description) : base(name, description) {}
        public override void Sound()
        {
            Console.WriteLine("Steamship makes a sound: Toot, toot");
        }
        public override void Show()
        {
            Console.WriteLine("Steamship: " + Name);
        }
        public override void Desc()
        {
            Console.WriteLine("Steamship description: " + Description);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Steamship) == false)
            {
                return false;
            }
            Steamship steamship = obj as Steamship;
            return GetHashCode() == steamship.GetHashCode();
        }
    }
}
