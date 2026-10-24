using Practice8InterfaceHome8;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice8InterfaceHome8
{
    class MyArray : IOutput, IMath, ICalc, IOutput2, ICalc2
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
        public int Less(int valueToCompare)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item < valueToCompare) count++;

            }
            return count;
        }
        public int Greater(int valueToCompare)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item > valueToCompare) count++;
            }
            return count;
        }
        public void ShowEven()
        {
            Console.Write("Even values: ");
            foreach (var item in array)
            {
                if (item % 2 == 0) Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void ShowOdd()
        {
            Console.Write("Odd values: ");
            foreach (var item in array)
            {
                if (item % 2 != 0) Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public int CountDistinct()
        {
            if (array == null || array.Length == 0) return 0;
            int distinctCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isUnique = true;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique) distinctCount++;
            }
            return distinctCount;
        }
        public int EqualToValue(int valueToCompare)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item == valueToCompare) count++;
            }
            return count;
        }
    }
}
