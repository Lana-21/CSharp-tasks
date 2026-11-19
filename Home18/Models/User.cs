using System;
using System.Collections.Generic;
using System.Text;

namespace Practice18.Models
{
    public class User
    {
        public string FirstName { get; set; } = "unknown";
        public string LastName { get; set; } = "unknown";
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = "unknown";
        public string Login { get; set; } = "unknown";
        public string Password { get; set; } = "unknown";
        public override string ToString() => $"User: {FirstName} {LastName}  Login: {Login}  Email: {Email}";
    }
}
