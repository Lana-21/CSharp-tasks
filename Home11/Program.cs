using static System.Console;
namespace Home11GENERICS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання1
            Footballer[] players =
             {
                new Footballer("Olech", 11, Player.Goalkeeper),
                new Footballer("Taras", 5, Player.Midfielder)
            };
            FootballTeam team = new(players);
            team.AddPlayer(new Footballer("Ihor", 1, Player.Forward));
            WriteLine("Team:");
            foreach (var player in team)
            {
                WriteLine(player);
            }
        }
    }
}
