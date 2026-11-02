using System;
using System.Collections.Generic;
using System.Text;

namespace Home12List.utils
{
    public static class DictGen
    {
        public static Dictionary<string, List<string>> GenDictionary()
        {
            return new Dictionary<string, List<string>>()
            {
                { "car", new List<string> { "voiture", "auto" } },
                { "book", new List<string> { "livre" } },
                { "water", new List<string> { "eau" } },
                { "friend", new List<string> { "ami", "copain" } }
            };
        }
    }
}
