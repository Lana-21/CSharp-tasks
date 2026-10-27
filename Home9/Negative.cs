using System;
using System.Collections.Generic;
using System.Text;

namespace Home9Delegate
{
    public class Negative
    {
        public static Func<int[], int[]> GetUniqueNegative = arr =>
        {
            if (arr == null) return new int[0];
            int[] temp = new int[arr.Length];
            int count = 0;
            foreach (int n in arr)
            {
                if (n < 0)
                {
                    bool exists = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (temp[i] == n)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        temp[count] = n;
                        count++;
                    }
                }
            }
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }
            return result;
        };
    }
}

