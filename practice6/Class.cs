using System;
using System.Collections.Generic;
using System.Text;

namespace Practice6Operator
{
    class Employee
    {
        string? fullName;
        DateTime birthDate;
        string? phone;
        string? email;
        string? position;
        string? function;
        double salary;

        public Employee() { }
        public Employee(string fullName, DateTime birthDate, string phone, string email, string position, string function, double salary)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Position = position;
            Function = function;
            Salary = salary;
        }
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Full name cannot be empty");
                foreach (char c in value)
                {
                    if (char.IsDigit(c))
                        throw new ArgumentException("Error: Full name cannot contain digits");
                }
                fullName = value;
            }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Error: Birth date cannot be in the future");
                birthDate = value;
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Phone number cannot be empty");
                phone = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Error: Invalid email address");
                email = value;
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Position cannot be empty!");
                position = value;
            }
        }
        public string Function
        {
            get { return function; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Job function cannot be empty!");
                function = value;
            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Salary cannot be negative!");
                salary = value;
            }
        }
        public static Employee operator +(Employee emp, double amount)
        {
            emp.Salary += amount;
            return emp;
        }
        public static Employee operator -(Employee emp, double amount)
        {
            emp.Salary -= amount;
            return emp;
        }
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.salary == emp2.salary;
        }
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }
        public static bool operator >(Employee emp1, Employee emp2)
        {
            return emp1.salary > emp2.salary;
        }
        public static bool operator <(Employee emp1, Employee emp2)
        {
            return emp1.salary < emp2.salary;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Employee emp)
            {
                return ToString().Equals(emp.ToString());
            }
            return false;
        }
        public void InputData()
        {
            Console.WriteLine("Enter Full Name:");
            FullName = Console.ReadLine();
            Console.WriteLine("Enter Birth Date:");
            BirthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Phone Number:");
            Phone = Console.ReadLine();
            Console.WriteLine("Enter Work Email:");
            Email = Console.ReadLine();
            Console.WriteLine("Enter Position:");
            Position = Console.ReadLine();
            Console.WriteLine("Enter Job function:");
            Function = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            Salary = double.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"Employee: {fullName} \n Position: {position} \n Phone: {phone} \n Email: {email} \n BirthDate: {birthDate} \n Salary: {salary}";
        }
    }


    class CreditCard
    {
        string? cardNumber;
        string? cardHolder;
        string? cvc;
        DateTime expDate;
        double balance;

        public CreditCard() { }
        public CreditCard(string cardNumber, string cardHolder, string cvc, DateTime expDate, double balance)
        {
            CardNumber = cardNumber;
            CardHolder = cardHolder;
            Cvc = cvc;
            ExpDate = expDate;
            Balance = balance;
        }
        public static bool LunaValid(string number)
        {
            if (string.IsNullOrEmpty(number)) return false;
            int sum = 0;
            bool second = false;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(number[i])) return false;
                int digit = number[i] - '0';
                if (second)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9;
                }
                sum += digit;
                second = !second;
            }
            return sum % 10 == 0;
        }
        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                if (!LunaValid(value))
                    throw new ArgumentException("Error: Invalid card number");
                cardNumber = value;
            }
        }
        public string CardHolder
        {
            get { return cardHolder; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Error: Card holder cannot be empty");
                cardHolder = value;
            }
        }
        public string Cvc
        {
            get { return cvc; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 3)
                    throw new ArgumentException("Error: Invalid CVC");
                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                        throw new ArgumentException("Error: CVC must contain only digits");
                }
                cvc = value;
            }
        }
        public DateTime ExpDate
        {
            get { return expDate; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Error: Card has expired");
                expDate = value;
            }
        }
        public double Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Error: Balance cannot be negative!");
                balance = value;
            }
        }
        public static CreditCard operator +(CreditCard card, double amount)
        {
            card.Balance += amount;
            return card;
        }
        public static CreditCard operator -(CreditCard card, double amount)
        {
            card.Balance -= amount;
            return card;
        }
        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            return card1.cvc == card2.cvc;
        }
        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return !(card1 == card2);
        }
        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.balance > card2.balance;
        }
        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.balance < card2.balance;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is CreditCard card)
            {
                return ToString().Equals(card.ToString());
            }
            return false;
        }
        public void InputData()
        {
            Console.WriteLine("Enter Card Number (16 digits):");
            CardNumber = Console.ReadLine();
            Console.WriteLine("Enter Card Holder Name:");
            CardHolder = Console.ReadLine();
            Console.WriteLine("Enter CVC (3 digits):");
            Cvc = Console.ReadLine();
            Console.WriteLine("Enter Expiry Date (MM/dd/yyyy):");
            ExpDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Initial Balance:");
            Balance = double.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"Card: {cardNumber} \n Holder: {cardHolder} \n Expires: {expDate} \n CVC: {cvc} \n Balance: {balance}";
        }
    }
}
