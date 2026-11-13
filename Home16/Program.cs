using Home16FILE.utils;
using static System.Console;
namespace Home16FILE
{
    public class Program
    {
        static void Main(string[] args)
        {
            //task1
            string simplePath = "simple.txt";
            string fibPath = "fibonacci.txt";
            Random rand = new Random();
            int totalNumbers = 100;
            int simpleCount = 0;
            int fibCount = 0;
            using (StreamWriter simpleWriter = new StreamWriter(simplePath))
            using (StreamWriter fibWriter = new StreamWriter(fibPath))
            {
                for (int i = 0; i < totalNumbers; i++)
                {
                    int number = rand.Next(0, 1000);
                    if (Math.IsPrime(number))
                    {
                        simpleWriter.WriteLine(number);
                        simpleCount++;
                    }
                    if (Math.IsFibonacci(number))
                    {
                        fibWriter.WriteLine(number);
                        fibCount++;
                    }
                }
            }
            WriteLine($"Total generated numbers: {totalNumbers}\n");
            FileInfo simpleInfo = new FileInfo(simplePath);
            WriteLine($"Count of simple numbers: {simpleCount}");
            WriteLine($"File size: {simpleInfo.Length} bytes");
            WriteLine($"Full path: {simpleInfo.FullName}\n");
            FileInfo fibInfo = new FileInfo(fibPath);
            WriteLine($"Count of Fibonacci numbers: {fibCount}");
            WriteLine($"File size: {fibInfo.Length} bytes");
            WriteLine($"Full path: {fibInfo.FullName}");
            ReadKey();



            //task2
            string path = @".\..\..\..\textfile.txt";
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                File.WriteAllText(fileInfo.FullName, "Hello world! This is a test file. Hello world! This is a test file.");
                WriteLine("textfile.txt was created \n");
            }
            WriteLine("Word Replacer");
            Write("Enter the word to search for: ");
            string searchWord = ReadLine();
            Write("Enter the replacement word: ");
            string replaceWord = ReadLine();
            int replacementsCount = FileManager.ReplaceWord(fileInfo, searchWord, replaceWord);
            WriteLine("Statistics");
            WriteLine($"Target file: {fileInfo.Name}");
            WriteLine($"Searched word: '{searchWord}'");
            WriteLine($"Replacement word: '{replaceWord}'");
            WriteLine($"Total replacements: {replacementsCount}");
            ReadKey();



            //task3
            Write("Enter the path to text file: ");
            string textPath = ReadLine();
            FileInfo textFile = new FileInfo(textPath);
            if (!textFile.Exists)
            {
                WriteLine("Error");
                return;
            }
            Write("Enter the path to moderation file: ");
            string wordsPath = ReadLine();
            FileInfo wordsFile = new FileInfo(wordsPath);
            if (!wordsFile.Exists)
            {
                WriteLine("Error");
                return;
            }
            string text = File.ReadAllText(textFile.FullName);
            string wordsText = File.ReadAllText(wordsFile.FullName);
            string[] badWords = wordsText.Split(new char[] { ' ', ',', '.', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in badWords)
            {
                string asterisks = new string('*', word.Length);
                text = text.Replace(word, asterisks);
            }
            File.WriteAllText(textFile.FullName, text);
            WriteLine(text);
            ReadKey();



            //task4
            //Write("Enter the path to the original file: ");
            //string path = ReadLine();
            //FileInfo fileInfo = new FileInfo(path);
            //if (!fileInfo.Exists)
            //{
            //    WriteLine("Error");
            //    return;
            //}
            //string content;
            //using (StreamReader reader = new StreamReader(fileInfo.FullName))
            //{
            //    content = reader.ReadToEnd();
            //}
            //string reversedContent = new string(content.Reverse().ToArray());
            //string newPath = Path.Combine(fileInfo.DirectoryName, "reversed_" + fileInfo.Name);
            //File.WriteAllText(newPath, reversedContent);
            //WriteLine("\nFile content successfully reversed!");
            //WriteLine($"New file created: {newPath}");
            //ReadKey();



            //task5
            //Write("Enter the path to the file: ");
            //string inputPath = ReadLine();
            //FileInfo fileInfo = new FileInfo(inputPath);
            //if (!fileInfo.Exists)
            //{
            //    WriteLine("Error");
            //    return;
            //}
            //int positiveCount = 0;
            //int negativeCount = 0;
            //int twoDigitCount = 0;
            //int fiveDigitCount = 0;
            //List<string> positiveNumbers = new List<string>();
            //List<string> negativeNumbers = new List<string>();
            //List<string> twoDigitNumbers = new List<string>();
            //List<string> fiveDigitNumbers = new List<string>();
            //using (StreamReader reader = new StreamReader(fileInfo.FullName))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        if (int.TryParse(line.Trim(), out int number))
            //        {
            //            if (number > 0)
            //            {
            //                positiveCount++;
            //                positiveNumbers.Add(number.ToString());
            //            }
            //            if (number < 0)
            //            {
            //                negativeCount++;
            //                negativeNumbers.Add(number.ToString());
            //            }
            //            int absNum = System.Math.Abs(number);
            //            if (absNum >= 10 && absNum <= 99)
            //            {
            //                twoDigitCount++;
            //                twoDigitNumbers.Add(number.ToString());
            //            }
            //            if (absNum >= 10000 && absNum <= 99999)
            //            {
            //                fiveDigitCount++;
            //                fiveDigitNumbers.Add(number.ToString());
            //            }
            //        }
            //    }
            //}
            //string directory = fileInfo.DirectoryName ?? "";
            //File.WriteAllLines(Path.Combine(directory, "positive.txt"), positiveNumbers);
            //File.WriteAllLines(Path.Combine(directory, "negative.txt"), negativeNumbers);
            //File.WriteAllLines(Path.Combine(directory, "twodigit.txt"), twoDigitNumbers);
            //File.WriteAllLines(Path.Combine(directory, "fivedigit.txt"), fiveDigitNumbers);
            //WriteLine($"Positive numbers count: {positiveCount}");
            //WriteLine($"Negative numbers count: {negativeCount}");
            //WriteLine($"Two-digit numbers count: {twoDigitCount}");
            //WriteLine($"Five-digit numbers count: {fiveDigitCount}");
            //ReadKey();
        }
    }
}
