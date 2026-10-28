using System;
using System.Collections.Generic;
using System.Text;

namespace Practice10
{
    public static class ArrayExtensions
    {
        public static int[] Filter(this int[] arr, Predicate<int> condition)
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
    }
}

