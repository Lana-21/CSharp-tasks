namespace Home4
{
    // завдання 6
    class Employee
    {
        string? fullName;
        DateTime birthDate;
        string? phone;
        string? email;
        string? position;
        string? function;

        public Employee() { }
        public Employee(string fullName) : this()
        {
            this.fullName = fullName;
        }
        public Employee(string fullName, DateTime birthDate, string phone, string email, string position, string function)
        {
            this.fullName = fullName;
            BirthDate = birthDate;
            this.phone = phone;
            this.email = email;
            this.position = position;
            this.function = function;
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
        }
        public override string ToString()
        {
            return $"Employee: {fullName} \n Position: {position} \n Phone: {phone} \n Email: {email} \n BirthDate: {birthDate.ToShortDateString()}";
        }
    }
    //static void Main(string[] args)
    //    {
    //        Employee employee;
    //        try
    //        {
    //            employee = new Employee();
    //            WriteLine("Employer default");
    //            WriteLine(employee);
    //            WriteLine();
    //            WriteLine("Employee data entry");
    //            employee.InputData();
    //            WriteLine("\nResult");
    //            WriteLine(employee);
    //        }
    //        catch (FormatException my)
    //        {
    //            WriteLine("Format Error " + my.Message);
    //        }
    //        catch (ArgumentException my)
    //        {
    //            WriteLine("Argument Error " + my.Message);
    //        }
    //        catch (OverflowException my)
    //        {
    //            WriteLine("Overflow Error: " + my.Message);
    //        }
    //        catch (Exception my)
    //        {
    //            WriteLine(my.Message);
    //        }
    //        WriteLine("\nPress any key to exit ");
    //        ReadKey();
    //    }


//завдання 5
class CreditCard
    {
        string cardNumber;
        string cardHolder;
        string cvc;
        DateTime expDate;
        public CreditCard()
        {
            cardNumber = "4532015112830366"; 
            cardHolder = "Unknown";
            cvc = "000";
            expDate = new DateTime();
        }
        public CreditCard(string cardNumber, string cardHolder, string cvc, DateTime expDate)
        {
            CardNumber = cardNumber;
            Cvc = cvc;            
            this.cardHolder = cardHolder;
            ExpDate = expDate;
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
            set { cardHolder = value; }
        }
        public string Cvc
        {
            get { return cvc; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 3)
                    throw new ArgumentException("Error: Invalid CVC");
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
        public void InputData()
        {
            Console.WriteLine("Enter Card Number (16 digits):");
            CardNumber = Console.ReadLine();
            Console.WriteLine("Enter Card Holder Name:");
            CardHolder = Console.ReadLine();
            Console.WriteLine("Enter CVC (3 digits):");
            Cvc = Console.ReadLine(); 
            Console.WriteLine("Enter Expiry Date (MM/YY):");
            ExpDate = DateTime.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"Card: {cardNumber} \n Holder: {cardHolder} \n Expires: {expDate} \n CVC: {cvc}";
        }
    }
}
//static void Main(string[] args)
//    {
//        CreditCard card;
//        try
//        {
//            card = new CreditCard();
//            WriteLine("Default Card");
//            WriteLine(card); 
//            WriteLine("\nEnter Card Data");
//            card.InputData();
//            WriteLine("\nResult");
//            WriteLine(card);
//        }
//        catch (FormatException my)
//        {
//            WriteLine("Format Error: " + my.Message);
//        }
//        catch (ArgumentException my)
//        {
//            WriteLine("Argument Error: " + my.Message);
//        }
//        catch (OverflowException my)
//        {
//            WriteLine("Overflow Error: " + my.Message);
//        }
//        catch (Exception my)
//        {
//            WriteLine("Error: " + my.Message);
//        }
//        WriteLine("\nPress any key to exit ");
//        ReadKey();
//    }



