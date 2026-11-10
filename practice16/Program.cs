using static System.Console;
namespace Practice16FILE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task4
            DirectoryInfo myDir = new("MyDirectory");
            if (!myDir.Exists)
                myDir.Create();
            var arrFileTxt = Directory.GetFiles(@"..\..\..\", "*.txt");
            foreach (string file in arrFileTxt)
            {
                WriteLine(file);
            }
            WriteLine("\n DirectoryInfo");
            var arrFile = new DirectoryInfo(@"..\..\..\").GetFiles("*.txt");
            foreach (var file in arrFile)
            {
                WriteLine($"{file.FullName}: {file.Name}");
                file.MoveTo(Path.Combine("MyDirectory", file.Name));
            }
            ReadKey();



            //task5
            //    Write("Source folder: ");
            //    string src = ReadLine();
            //    Write("Target folder: ");
            //    string dst = ReadLine();
            //    try
            //    {
            //        DirectoryInfo dir = new(src);
            //        if (dir.Exists)
            //        {
            //            CopyDirectory(dir, dst);
            //            WriteLine("\nSuccess");
            //        }
            //        else WriteLine("\nError");
            //    }
            //    catch (Exception ex)
            //    {
            //        WriteLine($"\nError: {ex.Message}");
            //    }
            //    ReadKey();
            //}
            //static void CopyDirectory(DirectoryInfo srcDir, string targetPath)
            //{
            //    Directory.CreateDirectory(targetPath);
            //    foreach (var file in srcDir.GetFiles())
            //        file.CopyTo(Path.Combine(targetPath, file.Name));
            //}




            //task1
            Write("Enter the path to file: ");
            string path = ReadLine();
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                WriteLine("\nFile");
                using (var fileStream = fileInfo.OpenRead())
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            WriteLine(line);
                        }
                    }
                }
            }
            else
            {
                WriteLine($"\nError: File not exist");
            }
            ReadKey();




            //task2
            string evenPath = "evens.txt";
            string oddPath = "odds.txt";
            Random rand = new Random();
            int totalNumbers = 10000;
            int evenCount = 0;
            int oddCount = 0;
            using (StreamWriter evenWriter = new StreamWriter(evenPath))
            using (StreamWriter oddWriter = new StreamWriter(oddPath))
            {
                for (int i = 0; i < totalNumbers; i++)
                {
                    int number = rand.Next(0, 100000);
                    if (number % 2 == 0)
                    {
                        evenWriter.WriteLine(number);
                        evenCount++;
                    }
                    else
                    {
                        oddWriter.WriteLine(number);
                        oddCount++;
                    }
                }
            }
            FileInfo evenInfo = new FileInfo(evenPath);
            WriteLine("Even numbers file (evens.txt):");
            WriteLine($"Count of numbers: {evenCount}");
            WriteLine($"File size: {evenInfo.Length} bytes");
            WriteLine($"Full path: {evenInfo.FullName}\n");
            FileInfo oddInfo = new FileInfo(oddPath);
            WriteLine("Odd numbers file (odds.txt):");
            WriteLine($"Count of numbers: {oddCount}");
            WriteLine($"File size: {oddInfo.Length} bytes");
            WriteLine($"Full path: {oddInfo.FullName}");
            ReadKey();
        }
    }
}




