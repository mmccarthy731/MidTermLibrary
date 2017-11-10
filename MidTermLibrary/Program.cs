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
            Console.WriteLine("Wait for it...");
            ASCII.DisplayASCII();
            List<string> menuOptions = new List<string>();
            Library.GetMainMenu(menuOptions);
            List<Book> books = TextEdit.ReadFile("../../library.txt");

            bool keepReading = true;
            while (keepReading)
            {
                Console.WriteLine("\nMain Menu:\n");
                Library.DisplayMainMenu(menuOptions);
                keepReading = Validator.GetUserChoice("Please select an option from the list above: ", menuOptions, books);
            }

            TextEdit.StoreBooksToFile(books);
            Console.WriteLine("\nGoodbye!");
        }
    }
}

