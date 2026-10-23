using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Kettle : Device
    {
        public Kettle() : base() {}
        public Kettle(string name, string description) : base(name, description) {}
        public override void Sound()
        {
            Console.WriteLine("Kettle makes a sound: bubbling");
        }
        public override void Show()
        {
            Console.WriteLine("Kettle: " + Name);
        }
        public override void Desc()
        {
            Console.WriteLine("Kettle description: " + Description);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Kettle) == false)
            {
                return false;
            }
            Kettle kettle = obj as Kettle;
            return GetHashCode() == kettle.GetHashCode();
        }
    }
}
