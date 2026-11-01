using Practice12List.models;
using Practice12List.services;
using Practice12List.utils;
using static System.Console;

namespace Practice12List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Book> books = BookGen.GenBooks(4);
            ServiceLinkedListBook library = new ServiceLinkedListBook(books);
            string menu = """
    0. Exit
    1. Insert book at the beginning
    2. Insert book at the end
    3. Insert book at a specific position
    4. Remove book from the beginning
    5. Remove book from the end
    6. Remove book from a specific position
    7. Update book information
    8. Show book list
    9. Search books (by title / author)
    """;
            int choice;
            do
            {
                Clear();
                WriteLine(menu);
                Write("\nChoose an operation: ");
                if (!int.TryParse(ReadLine(), out choice))
                {
                    WriteLine("\nInvalid input format. Press any key");
                    ReadKey();
                    continue;
                }
                if (choice == 0) break;
                switch (choice)
                {
                    case 1: 
                        library.AddFirst(BookGen.GenBook());
                        WriteLine("\nBook successfully added to the beginning!");
                        break;
                    case 2:
                        library.AddLast(BookGen.GenBook());
                        WriteLine("\nBook successfully added to the end!");
                        break;
                    case 3: 
                        library.ShowList();
                        Write("\nEnter index for insertion (starting from 0): ");
                        if (int.TryParse(ReadLine(), out int insIdx))
                        {
                            if (library.AddAt(insIdx, BookGen.GenBook()))
                                WriteLine("Book successfully inserted!");
                            else WriteLine("Error: invalid index!");
                        }
                        break;
                    case 4:
                        WriteLine($"\n{library.RemoveFirst()}");
                        break;
                    case 5: 
                        WriteLine($"\n{library.RemoveLast()}");
                        break;
                    case 6: 
                        library.ShowList();
                        Write("\nEnter index of book to remove: ");
                        if (int.TryParse(ReadLine(), out int delIdx))
                        {
                            WriteLine($"\n{library.RemoveAt(delIdx)}");
                        }
                        break;
                    case 7:
                        library.ShowList();
                        Write("\nEnter book index to update: ");
                        if (int.TryParse(ReadLine(), out int updIdx))
                        {
                            var newBook = BookGen.GenBook();
                            if (library.UpdateBook(updIdx, newBook))
                                WriteLine($"\nBook successfully updated to: {newBook}");
                            else WriteLine("Error: invalid index!");
                        }
                        break;
                    case 8:
                        WriteLine("Book list:\n");
                        library.ShowList();
                        break;
                    case 9:
                        Write("Search by (1 - Title, 2 - Author): ");
                        string type = ReadLine();
                        Write("Enter search query: ");
                        string query = ReadLine();
                        LinkedList<Book> results;
                        if (type == "1") results = library.SearchByTitle(query);
                        else results = library.SearchByAuthor(query);
                        WriteLine($"\nFound: {results.Count} books");
                        foreach (var b in results)
                        {
                            WriteLine($"- {b.Title} ({b.Author})");
                        }
                        break;
                    default:
                        break;
                }
                ReadKey();
            } while (true);
        }
    }
}
