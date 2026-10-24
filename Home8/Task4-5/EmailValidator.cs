using System;
using System.Collections.Generic;
using System.Text;

namespace Home8
{
    class EmailValidator : IValidator
    {
        private string email;

        public EmailValidator(string email)
        {
            this.email = email;
        }
        public bool Validate()
        {
            if (!string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains("."))
            {
                Console.WriteLine($"Email {email} is valid");
                return true;
            }
            Console.WriteLine($"Email {email} is invalid.");
            return false;
        }
    }
}
