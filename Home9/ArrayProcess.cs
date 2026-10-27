using System;
using System.Collections.Generic;
using System.Text;

namespace Home9Delegate
{
    public class ArrayProcess
    {
        public static int[] FilterArray(int[] arr, Predicate<int> condition)
        {
            if (arr == null || condition == null)
                return new int[0];
            int count = 0;
            foreach (var el in arr) if (condition(el)) count++;
            int[] result = new int[count];
            int index = 0;
            foreach (var el in arr) if (condition(el)) result[index++] = el;
            return result;
        }
        public static bool IsSimple(int number)
        {
            if (number <= 1 || (number % 2 == 0 && number != 2)) return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        public static bool IsFibonacci(int n)
        {
            if (n < 0) return false;
            int a = 0;
            int b = 1;
            while (a < n)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a == n;
        }
    }
}

