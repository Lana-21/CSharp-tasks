using System;
using System.Collections.Generic;
using System.Text;

namespace Home9Delegate
{
    public class ArraySeven
    {
        public static Func<int[], int> CountSeven = arr =>
        {
            if (arr == null) return 0;
            int count = 0;
            foreach (int n in arr) if (n % 7 == 0) count++;
            return count;
        };
    }
}
