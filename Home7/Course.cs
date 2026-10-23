using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class Course
    {
        private string name;
        private int duration;
        public Course()
        {
            Name = "Unknown";
            Duration = 0;
        }
        public Course(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name cannot be empty");
                }
                name = value;
            }
        }
        public int Duration
        {
            get { return duration; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration must be greater than zero");
                }
                duration = value;
            }
        }
        public override string ToString()
        {
            return "Course: " + Name + ", Duration: " + Duration + " hours";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Course) == false)
            {
                return false;
            }
            Course course = obj as Course;
            return GetHashCode() == course.GetHashCode();
        }
    }
}
