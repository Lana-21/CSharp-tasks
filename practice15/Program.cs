using Practice15;
using static System.Console;
namespace Practice15
{
    public class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            //Console.WriteLine("Film List");
            //List<Film> catalog = new()
            //{
            //    new Film("Spider-Man", "Columbia Pictures", FilmGenre.Fantasy, 169, 2014),
            //    new Film("Gladiator", "Universal Pictures", FilmGenre.Drama, 155, 2000),
            //    new Film("Interstellar", "Syncopy", FilmGenre.SciFi, 169, 2014)
            //};
            //Console.WriteLine($"\nTotal film objects created: {Film.TotalFilmsCreated}\n");
            //int searchYear = 2014;
            //Console.WriteLine($"\nFilms released in {searchYear}:");
            //var filteredByYear = catalog.Where(f => f.ReleaseYear == searchYear);
            //foreach (var film in filteredByYear)
            //{
            //    film.Display();
            //}
            //Console.WriteLine("\nChecking Dispose and GC.SuppressFinalize");
            //Console.WriteLine("\nCreating a film:");
            //using (Film disposableFilm = new Film("Avatar", "20th Century Fox", FilmGenre.SciFi, 162, 2025))
            //{
            //    disposableFilm.Display();
            //    Console.WriteLine($"\nTotal film objects created: {Film.TotalFilmsCreated}\n");
            //}
            //CreateForgottenFilm();
            //Console.WriteLine("\nGarbage Collector");
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //Console.WriteLine($"\nTotal film objects created: {Film.TotalFilmsCreated}\n");
            //Console.ReadKey();
            //static void CreateForgottenFilm()
            //{
            //    Film forgotten = new Film("Inception", "Warner Bros", FilmGenre.Romance, 195, 2020);
            //    forgotten.Display();
            //    Console.WriteLine($"\nTotal film objects created: {Film.TotalFilmsCreated}\n");
            //}


            //завдання2
            Console.WriteLine("TheaterCatalog");
            List<Play> catalog = new()
            {
                new Play(),
                new Play("Hamlet", "National Theatre", PlayGenre.Tragedy, 180, new List<string> { "John Doe", "Jane Smith" }),
                new Play("Romeo and Juliet", "Globe Theatre", PlayGenre.Drama, 150, new List<string> { "Actor A", "Actor B" }),
                new Play("The Phantom of the Opera", "West End", PlayGenre.Musical, 160, new List<string> { "Actor C", "Actor D" })
            };
            Console.WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
            PlayGenre searchGenre = PlayGenre.Tragedy;
            Console.WriteLine($"Plays with genre {searchGenre}:");
            var filteredByGenre = catalog.Where(p => p.Genre == searchGenre);
            foreach (var play in filteredByGenre)
            {
                play.Display();
            }
            Console.WriteLine("\n= Checking Dispose and GC.SuppressFinalize");
            Console.WriteLine("\nCreating a play:");
            using (Play disposablePlay = new Play("Shakespeare", "Shakespeare Company", PlayGenre.Tragedy, 140, new List<string> { "ActorNEW" }))
            {
                disposablePlay.Display();
                Console.WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
            }
            CreateForgottenPlay();
            Console.WriteLine("\nRunning Garbage Collector");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
            Console.ReadKey();
        }
        static void CreateForgottenPlay()
        {
            Play forgotten = new Play("Othello", "Broadway", PlayGenre.Tragedy, 170, new List<string> { "Actor Y" });
            forgotten.Display();
            Console.WriteLine($"\nTotal play objects created: {Play.TotalPlaysCreated}\n");
        }
    }
}




