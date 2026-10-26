using System;
using System.Collections.Generic;
using System.Text;

namespace Practice9Delegate
{
    public static class StringExtensions
    {
        public static int CountWords(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    char firstChar = char.ToLower(word[0]);
                    char lastChar = char.ToLower(word[word.Length - 1]);
                    if (firstChar == lastChar) count++;
                }
            }
            return count;
        }
    }
}
