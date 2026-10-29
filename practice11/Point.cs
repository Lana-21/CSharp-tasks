using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Practice11GENERICS
{
    public struct Point<T> where T : INumber<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString() => $"({X}; {Y})";
    }
}
