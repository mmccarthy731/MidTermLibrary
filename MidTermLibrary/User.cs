using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class User
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int pin;

        public int Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private int numberOfBooks;

        public int NumberOfBooks
        {
            get { return numberOfBooks; }
            set { numberOfBooks = value; }
        }

        public User(string name, int pin, int numberOfBooks)
        {
            this.name = name;
            this.pin = pin;
            this.numberOfBooks = numberOfBooks;
        }

        public static User GetUser(List<User> users)
        {
            Console.Write("\n1. Sign into existing account\n2. Create new account\n\nPlease choose an option from the list above (1 or 2): ");
            string input = Console.ReadLine();
            if(input == "1")
            {
                User user = SignIn(users);
                return user;
                
            }
            else if(input == "2")
            {
                User user = GetNewUser(users);
                return user;
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please Try again.");
                return GetUser(users);
            }
        }

        public static User GetNewUser(List<User> users)
        {
            Console.Write("\nPlease enter a username for your account: ");
            string nameInput = Console.ReadLine();
            foreach(User user in users)
            {
                if(user.Name.ToLower() == nameInput.ToLower())
                {
                    Console.WriteLine($"\nSorry, the username {nameInput} has already been taken. Please try again.");
                    return GetNewUser(users);
                }
            }
            string name = nameInput;
            Console.Write("\nPlease enter a PIN number for your account (4 digits, numbers only): ");
            string pinInput = Console.ReadLine();
            bool success = int.TryParse(pinInput, out int pinNumber);
            while(pinInput.Length != 4 || !success)
            {
                Console.Write("\nInvalid input. Please enter a 4-digit number: ");
                pinInput = Console.ReadLine();
                success = int.TryParse(pinInput, out pinNumber);
            }
            int pin = pinNumber;
            int numberOfBooks = 0;

            users.Add(new User(name, pin, numberOfBooks));
            return users[users.Count - 1];
        }

        public static User SignIn(List<User> users)
        {
            Console.Write("\nPlease enter the username for your account: ");
            string nameInput = Console.ReadLine().ToLower();
            int index = -1;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name.ToLower() == nameInput)
                {
                    index = i;
                }
            }
            if (index == -1)
            {

                Console.WriteLine("\nSorry, we do not have an account with the username you provided. Please try again.");
                return SignIn(users);
            }

            int attempts = 5;
            Console.Write("\nPlease enter the PIN number for your account: ");
            string pinInput = Console.ReadLine();
            bool success = int.TryParse(pinInput, out int pin);
            while(!success || pin != users[index].Pin)
            {
                attempts--;
                if (attempts > 0)
                {
                    Console.Write($"\nIncorrect PIN. Please enter the PIN associated with your account ({attempts} attempts remaining): ");
                    success = int.TryParse(Console.ReadLine(), out pin);
                }
                else
                {
                    Console.WriteLine("\nYou have exceeded the maximum attempts. Goodbye.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            return users[index];
        }
    }
}
