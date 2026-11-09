using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Home15GC
{
    public enum PlayGenre
    {
        General,
        Drama,
        Comedy,
        Tragedy,
        Musical,
        Opera
    }
    public class Play : IDisposable
    {
        private static int totalPlaysCreated = 0;
        public string Title { get; init; } = "Unknown";
        public string Author { get; set; } = "Unknown";
        public PlayGenre Genre { get; set; } = PlayGenre.General;
        public int ReleaseYear { get; set; } = 2026;
        private bool isDisposed = false;
        public Play()
        {
            totalPlaysCreated++;
        }
        public Play(string title, string author, PlayGenre genre, int releaseYear)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ReleaseYear = releaseYear;
            totalPlaysCreated++;
            WriteLine($"Constructor: Play {Title} by {Author} has been created");
        }
        public static int TotalPlaysCreated
        {
            get { return totalPlaysCreated; }
        }
        public void Display()
        {
            if (isDisposed)
                throw new ObjectDisposedException(Title, "The object has already been disposed");

            WriteLine($"{Title} by {Author} {ReleaseYear} Genre: {Genre}");
        }
        public void Dispose()
        {
            _Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void _Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    WriteLine($"Dispose: Managed resources explicitly cleaned for play {Title}");
                }
                isDisposed = true;
            }
        }
        ~Play()
        {
            --totalPlaysCreated;
            _Dispose(false);
            WriteLine($"Destructor / Finalizer: Garbage Collector removed play {Title} because Dispose() was not called");
        }
    }
}
