using Practice10;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice10
{
    public record class Person
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required int Age { get; init; }
    }
    public static class PersonExtensions
    {
        public static double GetAverageAge(this Person[] persons)
        {
            if (persons == null || persons.Length == 0) return 0;
            double sum = 0;
            foreach (var person in persons)
            {
                sum += person.Age;
            }
            return sum / persons.Length;
        }
        public static Person GetYoungest(this Person[] persons)
        {
            if (persons == null || persons.Length == 0) return null;
            Person youngest = persons[0];
            foreach (var p in persons)
            {
                if (p.Age < youngest.Age) youngest = p;
            }
            return youngest;
        }
        public static Person GetOldest(this Person[] persons)
        {
            if (persons == null || persons.Length == 0) return null;
            Person oldest = persons[0];
            foreach (var p in persons)
            {
                if (p.Age > oldest.Age) oldest = p;
            }
            return oldest;
        }
    }
}




