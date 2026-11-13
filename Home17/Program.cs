using static System.Console;
using System.Text.Json;
using System.Xml.Serialization;

namespace Practice17
{
    public class Program
    {
        static void Main(string[] args)
        {
            //task2,3
            var options = new JsonSerializerOptions { WriteIndented = true };
            var journalsList = new List<Journal>
            {
                    new Journal
                    {
                        Name = "English Learner's Digest",
                        Publisher = "Language Media",
                        Date = new DateTime(2026, 2, 1),
                        Pages = 46,
                        Articles = new List<Article>
                        {
                            new Article { Title = "Past Simple", Chars = 4500, Preview = "Guide to regular and irregular verbs." },
                            new Article { Title = "Top 10 Phrasal Verbs", Chars = 1500, Preview = "Verbs for everyday English conversation." }
                        }
                    },
            };
            string jsonString = JsonSerializer.Serialize(journalsList, options);
            WriteLine("Serialized Journals");
            WriteLine(jsonString);
            ReadKey();
            string jsonFileName = "journalsInfo.json";
            using (StreamWriter writer = new StreamWriter(jsonFileName))
            {
                writer.Write(jsonString);
                WriteLine($"\nData saved to file");
            }
            List<Journal>? loadedJournals;
            using (StreamReader reader = new StreamReader(jsonFileName))
            {
                loadedJournals = JsonSerializer.Deserialize<List<Journal>>(reader.ReadToEnd());
                WriteLine("\nDeserialized Journals");
                if (loadedJournals != null)
                {
                    foreach (var journal in loadedJournals)
                    {
                        WriteLine(journal);
                    }
                }
                ReadKey();
                WriteLine("\nXML SERIALIZATION");
                var xmlSerializer = new XmlSerializer(typeof(List<Journal>));
                string xmlFileName = "journalsInfo.xml";
                using (var fileStream = new FileStream(xmlFileName, FileMode.Create))
                {
                    xmlSerializer.Serialize(fileStream, journalsList);
                }
                WriteLine($"Data saved to file {xmlFileName}");
                if (File.Exists(xmlFileName))
                {
                    string xmlString = File.ReadAllText(xmlFileName);
                    WriteLine(xmlString);
                }
                ReadKey();
                List<Journal>? loadedJournalsXml = null;
                using (var xmlReader = new FileStream(xmlFileName, FileMode.Open))
                {
                    loadedJournalsXml = xmlSerializer.Deserialize(xmlReader) as List<Journal>;
                }
                WriteLine("\nDeserialized XML");
                if (loadedJournalsXml != null)
                {
                    foreach (var journal in loadedJournalsXml)
                    {
                        WriteLine(journal);
                    }
                }
                ReadKey();
            }

            //task4
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //Journal[] journalsArray = new Journal[]
            //{
            //        new Journal
            //        {
            //            Name = "English Learner's Digest",
            //            Publisher = "Language Media",
            //            Date = new DateTime(2026, 2, 1),
            //            Pages = 46,
            //            Articles = new List<Article>
            //            {
            //                new Article { Title = "Past Simple", Chars = 4500, Preview = "Guide to regular and irregular verbs." },
            //                new Article { Title = "Top 10 Phrasal Verbs", Chars = 1500, Preview = "Verbs for everyday English conversation." }
            //            }
            //        },
            //        new Journal
            //        {
            //            Name = "Fluent English Magazine",
            //            Publisher = "Global Press",
            //            Date = new DateTime(2026, 4, 11),
            //            Pages = 32,
            //            Articles = new List<Article>
            //            {
            //                new Article { Title = "Advanced Idioms", Chars = 3000, Preview = "How to sound like a native speakers." }
            //            }
            //        }
            //};
            //string jsonString = JsonSerializer.Serialize(journalsArray, options);
            //WriteLine("Serialized Journals Array");
            //WriteLine(jsonString);
            //ReadKey();
            //string jsonFileName = "journalsInfo.json";
            //using (var fileStream = new FileStream(jsonFileName, FileMode.Create))
            //{
            //    JsonSerializer.Serialize(fileStream, journalsArray);
            //}
            //WriteLine("Data saved to JSON file");
            //Journal[]? loadedJournals = null;
            //using (var fileStream = new FileStream(jsonFileName, FileMode.Open))
            //{
            //    loadedJournals = JsonSerializer.Deserialize<Journal[]>(fileStream);
            //}
            //WriteLine("Deserialized Journals");
            //if (loadedJournals != null)
            //{
            //    foreach (var journal in loadedJournals)
            //    {
            //        WriteLine(journal);
            //    }
            //}
            //ReadKey();

        }
    }
}




