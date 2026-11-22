using System;

namespace EXAM3.Models
{
    public class User
    {
        public User() { }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public UserRole Role { get; set; } = UserRole.Player;
        public User(string username, string password, DateTime birthDate, UserRole role)
        {
            Username = username;
            Password = password;
            BirthDate = birthDate;
            Role = role;
        }
        public bool IsAdmin => Role == UserRole.Admin;
    }
}