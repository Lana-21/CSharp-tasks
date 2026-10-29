using System;
using System.Collections.Generic;
using System.Text;

namespace Practice11GENERICS
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString() => $"Name: {Name}, Age: {Age}";
    }
    public class Dolphin : Animal
    {
        public string Species { get; set; }
        public Dolphin(string name, int age, string species) : base(name, age)
        {
            Species = species;
        }
        public override string ToString() => $"Dolphin: {Name}, Age: {Age}, Species: {Species}";
    }
    public class Shark : Animal
    {
        public double Length { get; set; }
        public Shark(string name, int age, double length) : base(name, age)
        {
            Length = length;
        }
        public override string ToString() => $"Shark: {Name}, Age: {Age}, Length: {Length}m";
    }
}

