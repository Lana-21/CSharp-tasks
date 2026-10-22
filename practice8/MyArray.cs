using System;
using System.Collections.Generic;
using System.Text;

namespace Practice8Interface
{
    class MyArray : IOutput, IMath
    {
        public const int Size = 10;
        int[] array;
        public MyArray()
        {
            array = new int[Size];
        }
        public MyArray(params int[] items)
        {
            array = (items == null) ? new int[Size] : items;
        }
        public void Show()
        {
            Console.WriteLine(string.Join(", ", array));
        }
        public void Show(string info)
        {
            Console.WriteLine($"{info}: {string.Join(", ", array)}");
        }
        public int Max()
        {
            if (array == null || array.Length == 0) return 0;
            int max = array[0];
            foreach (var item in array)
            {
                if (item > max) max = item;
            }
            return max;
        }
        public int Min()
        {
            if (array == null || array.Length == 0) return 0;
            int min = array[0];
            foreach (var item in array)
            {
                if (item < min) min = item;
            }
            return min;
        }
        public float Avg()
        {
            if (array == null || array.Length == 0) return 0;
            float sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum / array.Length;
        }
        public bool Search(int search)
        {
            return (Array.IndexOf(array, search) == -1) ? false : true;
        }
    }
}
