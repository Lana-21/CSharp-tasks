using Practice12List.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice12List.utils
{
    public static class BookGen
    {
            private static string[] titles = { "Kobzar", "Shadows of Forgotten Ancestors", "Zakhar Berkut", "Tygrolovu", "Fata Morgana" };
            private static string[] authors = { "T. Shevchenko", "M. Kotsiubynsky", "I. Franko", "I. Bahriany" };
            private static string[] genres = { "Poem", "Novella", "Novel", "Short Story" };
            private const int MinYear = 1840;
            private const int MaxYear = 2024;
            static Random rnd = new();
            public static string GenTitle()
            {
                return titles[rnd.Next(0, titles.Length)];
            }
            public static string GenAuthor()
            {
                return authors[rnd.Next(0, authors.Length)];
            }
            public static string GenGenre()
            {
                return genres[rnd.Next(0, genres.Length)];
            }
            public static int GenYear()
            {
                return rnd.Next(MinYear, MaxYear);
            }
            public static Book GenBook()
            {
                return new Book(
                     GenTitle(),
                     GenAuthor(),
                     GenGenre(),
                     GenYear()
                );
            }
            public static LinkedList<Book> GenBooks(int n)
            {
                LinkedList<Book> list = new();
                for (int i = 0; i < n; i++)
                {
                    list.AddLast(GenBook());
                }
                return list;
            }      
    }   
}

