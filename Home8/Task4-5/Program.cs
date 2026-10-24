namespace Home8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання4
            Console.WriteLine("\nTest IRemoteControl");
            IRemoteControl tv = new Television();
            tv.TurnOn();
            tv.SetChannel(9);
            tv.TurnOff();
            Console.WriteLine();
            IRemoteControl radio = new Radio();
            radio.TurnOn();
            radio.SetChannel(7);
            radio.TurnOff();

            //завдання5
            Console.WriteLine("\nTest IValidator");
            IValidator passValidator1 = new PasswordValidator("12345");
            passValidator1.Validate();
            IValidator passValidator2 = new PasswordValidator("Password123");
            passValidator2.Validate();
            Console.WriteLine();
            IValidator emailValidator1 = new EmailValidator("invalid-email.com");
            emailValidator1.Validate();
            IValidator emailValidator2 = new EmailValidator("user@example.com");
            emailValidator2.Validate();
        }
    }
}
