using Practice18.Models;
using Practice18.Services;
using Practice18.Utilities;
using Serilog;
using static System.Console;
namespace Practice18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\applog-.json", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                Log.Information("Start");
                List<User> usersList = FileService.LoadUsers() ?? new List<User>();
                MenuUtility.ShowMainMenu(usersList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
