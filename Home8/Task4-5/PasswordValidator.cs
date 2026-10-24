using System;
using System.Collections.Generic;
using System.Text;

namespace Home8
{
    public class PasswordValidator : IValidator
    {
        private string password;

        public PasswordValidator(string password)
        {
            this.password = password;
        }
        public bool Validate()
        {
            if (!string.IsNullOrEmpty(password) && password.Length >= 6)
            {
                Console.WriteLine($"Password {password} is valid");
                return true;
            }
            Console.WriteLine($"Password {password} is invalid");
            return false;
        }
    }
}

