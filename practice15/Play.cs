using System;
using System.Collections.Generic;
using System.Text;

namespace Practice15
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
        public string Theater { get; set; } = "Unknown";
        public PlayGenre Genre { get; set; } = PlayGenre.General;
        public int DurationMinutes { get; set; } = 100;
        public List<string> Actors { get; set; } = new();
        private bool isDisposed = false;
        public Play()
        {
            totalPlaysCreated++;
        }
        public Play(string title, string theater, PlayGenre genre, int durationMinutes, List<string> actors)
        {
            Title = title;
            Theater = theater;
            Genre = genre;
            DurationMinutes = durationMinutes;
            Actors = actors ?? new List<string>();
            totalPlaysCreated++;
            Console.WriteLine($"Constructor: Play {Title} has been created");
        }
        public static int TotalPlaysCreated
        {
            get { return totalPlaysCreated; }
        }
        public void Display()
        {
            if (isDisposed)
                throw new ObjectDisposedException(Title, "The object has already been disposed");
            string actorsList = Actors.Count > 0 ? string.Join(", ", Actors) : "No actors specified";
            Console.WriteLine($"{Title} at {Theater} ({Genre})  Duration: {DurationMinutes} mins  Actors: {actorsList}");
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
                    Console.WriteLine($"Dispose: Managed resources explicitly cleaned for play {Title}");
                }
                isDisposed = true;
            }
        }
        ~Play()
        {
            --totalPlaysCreated;
            _Dispose(false);
            Console.WriteLine($"Destructor / Finalizer: Garbage Collector removed play {Title} because Dispose() was not called");
        }
    }
}
