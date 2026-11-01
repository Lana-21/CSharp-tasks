using Practice12List.models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Practice12List.services
{
    public class ServiceLinkedListBook
    {
        public LinkedList<Book> Books { get; set; } = new LinkedList<Book>();
        public ServiceLinkedListBook(LinkedList<Book> books)
        {
            Books = books;
        }
        public void AddFirst(Book book) => Books.AddFirst(book);
        public void AddLast(Book book) => Books.AddLast(book);
        private LinkedListNode<Book> GetNodeAt(int index)
        {
            if (index < 0 || index >= Books.Count) return null;
            var current = Books.First;
            int i = 0;
            while (current != null)
            {
                if (i == index) return current;
                current = current.Next;
                i++;
            }
            return null;
        }
        public bool AddAt(int index, Book book)
        {
            if (index < 0 || index > Books.Count) return false;
            if (index == 0) { Books.AddFirst(book); 
                return true; }
            if (index == Books.Count) { Books.AddLast(book); 
                return true; }
            var targetNode = GetNodeAt(index);
            if (targetNode != null)
            {
                Books.AddBefore(targetNode, book);
                return true;
            }
            return false;
        }
        public string RemoveFirst()
        {
            if (Books.First == null) return "The list is empty";
            var removed = Books.First.Value;
            Books.RemoveFirst();
            return $"Removed from the beginning: {removed}";
        }
        public string RemoveLast()
        {
            if (Books.Last == null) return "The list is empty";
            var removed = Books.Last.Value;
            Books.RemoveLast();
            return $"Removed from the end: {removed}";
        }
        public string RemoveAt(int index)
        {
            var node = GetNodeAt(index);
            if (node == null) return "Error: invalid index";
            var removed = node.Value;
            Books.Remove(node);
            return $"Removed: {removed}";
        }
        public bool UpdateBook(int index, Book updatedBook)
        {
            var node = GetNodeAt(index);
            if (node == null) return false;
            node.Value = updatedBook;
            return true;
        }
        public LinkedList<Book> SearchByTitle(string title)
        {
            LinkedList<Book> result = new();
            foreach (var b in Books)
            {
                if (b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) result.AddLast(b); 
            }
            return result;
        }
        public LinkedList<Book> SearchByAuthor(string author)
        {
            LinkedList<Book> result = new();
            foreach (var b in Books)
            {
                if (b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)) result.AddLast(b); 
            }
            return result;
        }
        public void ShowList()
        {
            int i = 0;
            foreach (var book in Books)
            {
                WriteLine($"{++i}. Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Year: {book.Year}");
            }
        }
    }
}
