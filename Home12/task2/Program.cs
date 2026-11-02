static void Main(string[] args)
{
    var initialData = DictGen.GenDictionary();
    ServiceDictionary service = new(initialData);
    int choice = 0;
    string menu = """
0. Exit
1. Add word and translations
2. Add translation variant 
3. Remove word
4. Remove translation variant
5. Update word
6. Update translation variant
7. Search translation by English word
8. Show all dictionary 
""";
    do
    {
        Clear();
        WriteLine(menu);
        Write("\nYour choice: ");
        if (!int.TryParse(ReadLine(), out choice))
        {
            WriteLine("\nInvalid input format");
            ReadKey();
            continue;
        }
        if (choice == 0) break;
        switch (choice)
        {
            case 1:
                Write("Enter English word: ");
                string word = ReadLine();
                Write("Enter French translations: ");
                string inputTrans = ReadLine();
                List<string> transList = new List<string>(inputTrans.Split(',', StringSplitOptions.RemoveEmptyEntries));
                for (int i = 0; i < transList.Count; i++) transList[i] = transList[i].Trim();
                if (service.AddWord(word, transList))
                    WriteLine("\nWord successfully added");
                else WriteLine("\nError");
                break;
            case 2:
                Write("Enter existing English word: ");
                string w = ReadLine();
                Write("Enter new French translation to add: ");
                string t = ReadLine().Trim();
                if (service.AddTranslation(w, t))
                    WriteLine("\nTranslation variant added");
                else WriteLine("\nError");
                break;
            case 3:
                Write("Enter English word to remove: ");
                string delWord = ReadLine();
                if (service.RemoveWord(delWord))
                    WriteLine("\nWord successfully removed");
                else WriteLine("\nError");
                break;
            case 4:
                Write("Enter English word: ");
                string dw = ReadLine();
                Write("Enter French translation to remove: ");
                string dt = ReadLine().Trim();
                if (service.RemoveTranslation(dw, dt))
                    WriteLine("\nTranslation removed");
                else WriteLine("\nError");
                break;
            case 5:
                Write("Enter old English word: ");
                string oldW = ReadLine();
                Write("Enter new English word: ");
                string newW = ReadLine();
                if (service.UpdateWord(oldW, newW))
                    WriteLine("\nWord updated successfully");
                else WriteLine("\nError");
                break;
            case 6:
                Write("Enter English word: ");
                string uw = ReadLine();
                Write("Enter old French translation: ");
                string oldT = ReadLine().Trim();
                Write("Enter new French translation: ");
                string newT = ReadLine().Trim();
                if (service.UpdateTranslation(uw, oldT, newT))
                    WriteLine("\nTranslation updated successfully");
                else WriteLine("\nError");
                break;
            case 7:
                Write("Enter English word to search: ");
                string searchW = ReadLine();
                var result = service.SearchTranslation(searchW);
                if (result != null)
                    WriteLine($"\nTranslations for {searchW}: {string.Join(", ", result)}");
                else WriteLine("\nWord not found");
                break;
            case 8:
                WriteLine("\nFull Dictionary:");
                var all = service.GetAll();
                if (all.Count == 0) WriteLine("Dictionary is empty.");
                else
                {
                    int i = 0;
                    foreach (var kvp in all)
                    {
                        WriteLine($"{++i}. {kvp.Key} -> {string.Join(", ", kvp.Value)}");
                    }
                }
                break;
            default:
                break;
        }
        ReadKey();
    } while (true);
}
