using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Device
    {
        private string name;
        private string description;

        public Device()
        {
            Name = "Unknown";
            Description = "Unknown";
        }
        public Device(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Device name cannot be empty");
                }
                name = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Device description cannot be empty");
                }
                description = value;
            }
        }
        public virtual void Sound()
        {
            Console.WriteLine("The device makes a sound.");
        }
        public virtual void Show()
        {
            Console.WriteLine("Device name: " + Name);
        }
        public virtual void Desc()
        {
            Console.WriteLine("Device description: " + Description);
        }
        public override string ToString()
        {
            return "Device: " + Name + ", Description: " + Description;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Device) == false)
            {
                return false;
            }
            Device device = obj as Device;
            return GetHashCode() == device.GetHashCode();
        }
    }
}
