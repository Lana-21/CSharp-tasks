using System;
using System.Collections.Generic;
using System.Text;

namespace Practice17
{
    public class Journal
    {
        public Journal() { }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
        public int Pages { get; set; }
        public List<Article> Articles { get; set; } = new();
        public override string ToString()
        {
            return $"Journal: {Name}  Publisher: {Publisher}  Date: {Date.ToShortDateString()}  Total Pages: {Pages} \nArticles:\n" + string.Join("\n", Articles);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Publisher, Date, Pages);
        }
    }
}
