using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Home6
{
    //завдання1
    //class Shop
    //{
    //    string? name;
    //    string? address;
    //    double area; 

    //    public Shop() {}
    //    public Shop(string name, string address, double area)
    //    {
    //        Name = name;
    //        Address = address;
    //        Area = area;
    //    }
    //    public string Name
    //    {
    //        get { return name; }
    //        set
    //        {
    //            if (string.IsNullOrWhiteSpace(value))
    //                throw new ArgumentException("Error: Shop name cannot be empty!");
    //            name = value;
    //        }
    //    }
    //    public string Address
    //    {
    //        get { return address; }
    //        set
    //        {
    //            if (string.IsNullOrWhiteSpace(value))
    //                throw new ArgumentException("Error: Shop address cannot be empty!");
    //            address = value;
    //        }
    //    }
    //    public double Area
    //    {
    //        get { return area; }
    //        set
    //        {
    //            if (value < 0)
    //                throw new ArgumentException("Error: Shop area cannot be negative!");
    //            area = value;
    //        }
    //    }
    //    public static Shop operator +(Shop shop, double amount)
    //    {
    //        shop.Area += amount;
    //        return shop;
    //    }
    //    public static Shop operator -(Shop shop, double amount)
    //    {
    //        shop.Area -= amount;
    //        return shop;
    //    }
    //    public static bool operator ==(Shop shop1, Shop shop2)
    //    {
    //        return shop1.area == shop2.area;
    //    }
    //    public static bool operator !=(Shop shop1, Shop shop2)
    //    {
    //        return !(shop1 == shop2);
    //    }
    //    public static bool operator >(Shop shop1, Shop shop2)
    //    {
    //        return shop1.area > shop2.area;
    //    }
    //    public static bool operator <(Shop shop1, Shop shop2)
    //    {
    //        return shop1.area < shop2.area;
    //    }
    //    public override bool Equals(object? obj)
    //    {
    //        if (obj != null && obj is Shop shop)
    //        {
    //            return ToString().Equals(shop.ToString());
    //        }
    //        return false;
    //    }
    //    public void InputData()
    //    {
    //        WriteLine("Enter Shop Name:");
    //        Name = ReadLine();
    //        WriteLine("Enter Shop Address:");
    //        Address = ReadLine();
    //        WriteLine("Enter Shop Area:");
    //        Area = double.Parse(ReadLine());
    //    }
    //    public override string ToString()
    //    {
    //        return $"Shop: {name} \n Address: {address} \n Area: {area} sq.m";
    //    }
    //}

    //завдання2
    class Person
    {
        string firstName;
        string lastName;
        DateTime birthDate;

        public Person()
        {
            firstName = "Bob";
            lastName = "Johan";
            birthDate = new DateTime();
        }
        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: First name cannot be empty");
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Last name cannot be empty");
                lastName = value;
            }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Error: Birth date cannot be in the future");
                birthDate = value;
            }
        }
        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}
