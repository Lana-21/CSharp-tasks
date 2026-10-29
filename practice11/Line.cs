using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Practice11GENERICS
{
    public class Line<T> where T : INumber<T>
    {
        public Point<T> Point1 { get; set; }
        public Point<T> Point2 { get; set; }
        public Line(Point<T> p1, Point<T> p2)
        {
            Point1 = p1;
            Point2 = p2;
        }
        public Line(T x1, T y1, T x2, T y2)
        {
            Point1 = new Point<T>(x1, y1);
            Point2 = new Point<T>(x2, y2);
        }
        public double GetLength()
        {
            double x1 = double.CreateChecked(Point1.X);
            double y1 = double.CreateChecked(Point1.Y);
            double x2 = double.CreateChecked(Point2.X);
            double y2 = double.CreateChecked(Point2.Y);
            double dx = x2 - x1;
            double dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public bool IsPointOnLine(Point<T> p3)
        {
            T x1 = Point1.X;
            T y1 = Point1.Y;
            T x2 = Point2.X;
            T y2 = Point2.Y;
            T x3 = p3.X;
            T y3 = p3.Y;
            T product = (x3 - x1) * (y2 - y1) - (y3 - y1) * (x2 - x1);
            return product == T.Zero;
        }
        public override string ToString()
        {
            return $"straight line passing through points {Point1} та {Point2}";
        }
    }
}
