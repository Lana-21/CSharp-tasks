using System;
using System.Collections.Generic;
using System.Text;

namespace Home9Delegate
{
    public class Text
    {
        public static Func<string, string, bool> ContainsWord = (input, word) =>
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(word))
                return false;
            string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string w in words)
            {
                if (w.ToLower() == word.ToLower()) return true; 
            }
            return false;
        };
    }
}
