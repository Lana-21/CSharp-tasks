using System;
using System.Collections.Generic;
using System.Text;

namespace Home6
{
    class Article
    {
        Person author;
        string title;
        double rating;

        public Article()
        {
            author = new Person();
            title = "Default";
            rating = 0.0;
        }
        public Article(Person author, string title, double rating)
        {
            Author = author;
            Title = title;
            Rating = rating;
        }
        public Person Author
        {
            get { return author; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Error: Author cannot be null");
                author = value;
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Title cannot be empty");
                title = value;
            }
        }
        public double Rating
        {
            get { return rating; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Rating cannot be negative");
                rating = value;
            }
        }
        public override string ToString()
        {
            return $"{title} by {author} (Rating: {rating})";
        }
    }
}
