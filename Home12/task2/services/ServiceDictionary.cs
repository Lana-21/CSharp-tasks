using System;
using System.Collections.Generic;
using System.Text;

namespace Home12List.services
{
    public class ServiceDictionary
    {
        private Dictionary<string, List<string>> dict = new();
        public ServiceDictionary(Dictionary<string, List<string>> initialDict)
        {
            dict = initialDict;
        }
        public bool AddWord(string engWord, List<string> translations)
        {
            if (!dict.ContainsKey(engWord))
            {
                dict.Add(engWord, translations);
                return true;
            }
            return false;
        }
        public bool AddTranslation(string engWord, string translation)
        {
            if (dict.ContainsKey(engWord))
            {
                if (!dict[engWord].Contains(translation))
                {
                    dict[engWord].Add(translation);
                    return true;
                }
            }
            else
            {
                dict[engWord] = new List<string> { translation };
                return true;
            }
            return false;
        }
        public bool RemoveWord(string engWord)
        {
            return dict.Remove(engWord);
        }
        public bool RemoveTranslation(string engWord, string translation)
        {
            if (dict.ContainsKey(engWord))
            {
                return dict[engWord].Remove(translation);
            }
            return false;
        }
        public bool UpdateWord(string oldWord, string newWord)
        {
            if (dict.ContainsKey(oldWord) && !dict.ContainsKey(newWord))
            {
                var translations = dict[oldWord];
                dict.Remove(oldWord);
                dict[newWord] = translations;
                return true;
            }
            return false;
        }
        public bool UpdateTranslation(string engWord, string oldTranslation, string newTranslation)
        {
            if (dict.ContainsKey(engWord))
            {
                int index = dict[engWord].IndexOf(oldTranslation);
                if (index != -1)
                {
                    dict[engWord][index] = newTranslation;
                    return true;
                }
            }
            return false;
        }
        public List<string> SearchTranslation(string engWord)
        {
            if (dict.ContainsKey(engWord))
            {
                return dict[engWord];
            }
            return null;
        }
        public Dictionary<string, List<string>> GetAll()
        {
            return dict;
        }
    }
}
