using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Microwave : Device
    {
        public Microwave() : base() {}
        public Microwave(string name, string description) : base(name, description) {}
        public override void Sound()
        {
            Console.WriteLine("Microwave makes a sound: Beep, beep");
        }
        public override void Show()
        {
            Console.WriteLine("Microwave: " + Name);
        }
        public override void Desc()
        {
            Console.WriteLine("Microwave description: " + Description);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Microwave) == false)
            {
                return false;
            }
            Microwave microwave = obj as Microwave;
            return GetHashCode() == microwave.GetHashCode();
        }
    }
}
