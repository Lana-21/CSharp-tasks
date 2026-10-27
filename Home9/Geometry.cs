using System;
using System.Collections.Generic;
using System.Text;

namespace Home9Delegate
{
    public class Geometry
    {
        public static void ShowCurrentTime() => Console.WriteLine($"Current time: {DateTime.Now.ToLongTimeString()}");
        public static void ShowCurrentDate() => Console.WriteLine($"Current date: {DateTime.Now.ToShortDateString()}");
        public static void ShowCurrentDayOfWeek() => Console.WriteLine($"Day of week: {DateTime.Now.DayOfWeek}");
        public static bool IsValidValue(double value) => value > 0;
        public static double CalculateTriangleArea(double baseSide, double height)
        {
            return 0.5 * baseSide * height;
        }
        public static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
