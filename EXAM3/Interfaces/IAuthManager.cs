using EXAM3.Models;

namespace EXAM3.Interfaces
{
    public interface IAuthManager
    {
        User? CurrentUser { get; set; }
        void Register();
        void Login();
        void ChangeSettings();
    }
}