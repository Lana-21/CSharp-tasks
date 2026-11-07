using System;
using System.Collections.Generic;
using System.Text;

namespace Practice15
{
    public enum FilmGenre
    {
        General,
        Action,
        Animation,
        Drama,
        Fantasy,
        Romance
    }
    public class Film : IDisposable
    {
        private static int totalFilmsCreated = 0;
        public string Title { get; init; } = "Unknown";
        public string Studio { get; set; } = "Unknown";
        public FilmGenre Genre { get; set; } = FilmGenre.General;
        public int DurationMinutes { get; set; } = 100;
        public int ReleaseYear { get; set; } = 2026;
        private bool isDisposed = false;
        public Film()
        {
            totalFilmsCreated++;
        }
        public Film(string title, string studio, FilmGenre genre, int durationMinutes, int releaseYear)
        {
            Title = title;
            Studio = studio;
            Genre = genre;
            DurationMinutes = durationMinutes;
            ReleaseYear = releaseYear;
            totalFilmsCreated++;
            Console.WriteLine($"Constructor: Film {Title} has been created");
        }
        public static int TotalFilmsCreated
        {
            get { return totalFilmsCreated; }
        }
        public void Display()
        {
            if (isDisposed)
                throw new ObjectDisposedException(Title, "The object has already been disposed");
            Console.WriteLine($"{Title} ({ReleaseYear}) Genre: {Genre} Duration: {DurationMinutes} mins");
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
                    Console.WriteLine($"Dispose: Managed resources explicitly cleaned for film {Title}");
                }
                isDisposed = true;
            }
        }
        ~Film()
        {
            --totalFilmsCreated;
            _Dispose(false);
            Console.WriteLine($"Destructor / Finalizer: Garbage Collector removed film {Title} because Dispose() was not called");
        }
    }
}
