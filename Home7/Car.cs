using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Car : Device
    {
        public Car() : base() {}
        public Car(string name, string description) : base(name, description) {}
        public override void Sound()
        {
            Console.WriteLine("Car makes a sound: Beep-beep");
        }
        public override void Show()
        {
            Console.WriteLine("Car: " + Name);
        }
        public override void Desc()
        {
            Console.WriteLine("Car description: " + Description);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Car) == false)
            {
                return false;
            }
            Car car = obj as Car;
            return GetHashCode() == car.GetHashCode();
        }
    }
}
