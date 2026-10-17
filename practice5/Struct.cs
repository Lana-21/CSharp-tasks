using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5
{
    struct Birthday
    {
        private DateTime myDate;
        public Birthday(int year, int month, int day)
        {
            myDate = default; 
            Date = new DateTime(year, month, day); 
        }
        public DateTime Date
        {
            get { return myDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Error: Birth date cannot be in the future!");
                }
                myDate = value;
            }
        }
        public int MonthMyDate
        {
            get { return myDate.Month; }
        }
        public string MyDateOfWeek
        {
            get { return myDate.DayOfWeek.ToString(); }
        }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - myDate.Year;
                if (myDate.Date > DateTime.Now.AddYears(-age)) age--;
                return age;
            }
        }
        public DayOfWeek GetDayOfWeekInYear(int year)
        {
            if (year < myDate.Year)
            {
                throw new ArgumentException("Error: Target year cannot be earlier than birth year!");
            }
            DateTime birthdayInYear = new DateTime(year, myDate.Month, myDate.Day);
            return birthdayInYear.DayOfWeek;
        }
        public int GetDaysUntilNextBirthday()
        {
            DateTime today = DateTime.Today;
            DateTime nextBirthday = new DateTime(today.Year, myDate.Month, myDate.Day);
            if (nextBirthday < today) nextBirthday = nextBirthday.AddYears(1);
            return (int)(nextBirthday - today).TotalDays;
        }
        public override string ToString()
        {
            return $"Birthday: {myDate.Day}/{myDate.Month}/{myDate.Year} \n Day of week born: {MyDateOfWeek} \n Age: {Age}";
        }
    }
}
