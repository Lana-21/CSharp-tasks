using System;
using System.Collections.Generic;
using System.Text;

namespace Practice17
{
    public class Article
    {
        public Article() { }
        public const int CharsPerPage = 1500;
        public string Title { get; set; }
        public int Chars { get; set; }
        public string Preview { get; set; }
        public int PageCount => (int)(Chars / CharsPerPage);
        public override string ToString()
        {
            return $"Article: {Title} {Chars} chars, {PageCount} pages: {Preview}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Chars, Preview);
        }
    }
}
