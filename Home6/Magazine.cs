using System;
using System.Collections.Generic;
using System.Text;

namespace Home6
{
    public enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }
    class Magazine
    {
        string magazineTitle;
        Frequency frequency;
        DateTime releaseDate;
        int edition;
        Article[] articles;
        int employeesCount;

        public Magazine()
        {
            magazineTitle = "My Magazine";
            frequency = Frequency.Monthly;
            releaseDate = DateTime.Now;
            edition = 1000;
            articles = new Article[0];
            employeesCount = 10;
        }
        public Magazine(string magazineTitle, Frequency frequency, DateTime releaseDate, int edition, int employeesCount)
        {
            MagazineTitle = magazineTitle;
            Frequency = frequency;
            ReleaseDate = releaseDate;
            Edition = edition;
            articles = new Article[0];
            EmployeesCount = employeesCount;
        }
        public string MagazineTitle
        {
            get { return magazineTitle; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Magazine title cannot be empty");
                magazineTitle = value;
            }
        }
        public Frequency Frequency { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Edition
        {
            get { return edition; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Edition cannot be negative");
                edition = value;
            }
        }
        public Article[] Articles
        {
            get { return articles; }
            set { articles = (value == null) ? new Article[0] : value; }
        }
        public double AverageRating
        {
            get
            {
                if (articles == null || articles.Length == 0) return 0.0;
                double sum = 0;
                foreach (var art in articles)
                {
                    sum += art.Rating;
                }
                return sum / articles.Length;
            }
        }
        public int EmployeesCount
        {
            get { return employeesCount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Employees count cannot be negative");
                employeesCount = value;
            }
        }
        public void AddArticles(params Article[] newArticles)
        {
            if (newArticles == null || newArticles.Length == 0) return;
            int oldLength = articles.Length;
            Array.Resize(ref articles, oldLength + newArticles.Length);
            Array.Copy(newArticles, 0, articles, oldLength, newArticles.Length);
        }
        public static Magazine operator +(Magazine mag, int amount)
        {
            mag.EmployeesCount += amount;
            return mag;
        }
        public static Magazine operator -(Magazine mag, int amount)
        {
            mag.EmployeesCount -= amount;
            return mag;
        }
        public static bool operator ==(Magazine mag1, Magazine mag2)
        {
            return mag1.employeesCount == mag2.employeesCount;
        }
        public static bool operator !=(Magazine mag1, Magazine mag2)
        {
            return !(mag1 == mag2);
        }
        public static bool operator >(Magazine mag1, Magazine mag2)
        {
            return mag1.employeesCount > mag2.employeesCount;
        }
        public static bool operator <(Magazine mag1, Magazine mag2)
        {
            return mag1.employeesCount < mag2.employeesCount;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Magazine mag)
            {
                return ToString().Equals(mag.ToString());
            }
            return false;
        }
        public override string ToString()
        {
            return $"Magazine: {magazineTitle} \n Frequency: {frequency} \n Employees: {employeesCount}";
        }
    }
}
