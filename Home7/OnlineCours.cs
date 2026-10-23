using System;
using System.Collections.Generic;
using System.Text;

namespace Home7
{
    public class OnlineCourse : Course
    {
        private string platform;

        public OnlineCourse() : base()
        {
            Platform = "Unknown";
        }
        public OnlineCourse(string name, int duration, string platform) : base(name, duration)
        {
            Platform = platform;
        }
        public string Platform
        {
            get { return platform; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Platform name cannot be empty!");
                }
                platform = value;
            }
        }
        public override string ToString()
        {
            return "Online Course: " + Name + ", Duration: " + Duration + " hours, Platform: " + Platform;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || (obj is OnlineCourse) == false)
            {
                return false;
            }
            OnlineCourse onlineCourse = obj as OnlineCourse;
            return GetHashCode() == onlineCourse.GetHashCode();
        }
    }
}
