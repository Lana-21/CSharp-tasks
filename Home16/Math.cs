using System;
using System.Collections.Generic;
using System.Text;

namespace Home16FILE
{
    public static class Math
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
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
                int temp = a + b;
                a = b;
                b = temp;
            }
            return a == n;
        }
    }
}
