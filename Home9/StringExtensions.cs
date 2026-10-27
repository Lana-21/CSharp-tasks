using System;
using System.Collections.Generic;
using System.Text;

namespace Home9Delegate
{
    public static class StringExtensions
    {
        public static bool IsValidBrackets(this string str)
        {
            if (string.IsNullOrEmpty(str)) return true;
            int roundCount = 0; 
            int curlyCount = 0; 
            int squareCount = 0; 
            bool isValid = true;
            foreach (char c in str)
            {
                switch (c)
                {
                    case '(':
                        roundCount++;
                        break;
                    case ')':
                        roundCount--;
                        if (roundCount < 0) isValid = false;
                        break;
                    case '{':
                        curlyCount++;
                        break;
                    case '}':
                        curlyCount--;
                        if (curlyCount < 0) isValid = false;
                        break;
                    case '[':
                        squareCount++;
                        break;
                    case ']':
                        squareCount--;
                        if (squareCount < 0) isValid = false;
                        break;
                }
                if (!isValid) break;
            }
            return isValid && roundCount == 0 && curlyCount == 0 && squareCount == 0;
        }
    }
}
