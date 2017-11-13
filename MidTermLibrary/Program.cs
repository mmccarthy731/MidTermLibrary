using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = TextEdit.ReadLibrary("../../library.txt");
            List<User> users = TextEdit.ReadUsers("../../users.txt");

            Console.WriteLine("Wait for it...");
            ASCII.DisplayASCII();

            User user = User.GetUser(users);

            List<string> menuOptions = new List<string>();
            Library.GetMainMenu(menuOptions);

            bool keepReading = true;
            while (keepReading)
            {
                Console.WriteLine("\nMain Menu:\n");
                Library.DisplayMainMenu(menuOptions);
                keepReading = Validator.GetUserChoice("Please select an option from the list above: ", menuOptions, books, user);
            }

            TextEdit.WriteUsers(users);
            TextEdit.WriteLibrary(books);
            Console.WriteLine("\nGoodbye!");
        }
    }
}

