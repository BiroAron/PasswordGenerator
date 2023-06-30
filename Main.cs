using System;

public class Program
{
    public static void Main(string[] args)
    {
        int timer = 30;
        PasswordGenerator passGenerator = new PasswordGenerator(timer);

        while (true)
        {
            Console.WriteLine("Enter User ID:");
            string userId = Console.ReadLine();

            DateTime dateTime = DateTime.Now;

            string password = passGenerator.GeneratePassword(userId, dateTime);
            Console.WriteLine("Generated Password: " + password);
            int i = 0;
            bool isValid = true;
            while (30 > i++)
            {
                System.Threading.Thread.Sleep(1000);
                isValid = passGenerator.IsPasswordValid(userId, dateTime, password);
                if (isValid)
                {
                    Console.WriteLine("You have " + (30 - i) + " seconds left to use this password.");
                }
                else
                {
                    Console.WriteLine("Password is no longer valid.");
                }
            }
            Console.WriteLine();
        }
    }
}
