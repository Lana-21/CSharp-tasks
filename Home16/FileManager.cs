using System;
using System.Collections.Generic;
using System.Text;

namespace Home16FILE.utils
{
    public static class FileManager
    {
        public static int ReplaceWord(FileInfo fileInfo, string searchWord, string replaceWord)
        {
            if (!fileInfo.Exists || string.IsNullOrEmpty(searchWord))
            {
                return 0;
            }
            string content = File.ReadAllText(fileInfo.FullName);
            int count = content.Split(searchWord).Length - 1;
            string newContent = content.Replace(searchWord, replaceWord);
            File.WriteAllText(fileInfo.FullName, newContent);
            return count;
        }
    }
}    
