using System;
using System.Collections.Generic;
using System.Text;

namespace Practice12List.models
{
    public record class Book(
        string Title,
        string Author,
        string Genre,
        int Year);
}

