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
            Console.WriteLine("Weclome to the Midterm Library.");
            List<string> menuOptions = new List<string>();

            menuOptions.Add("1. View all books");
            menuOptions.Add("2. Search for a book by author");
            menuOptions.Add("3. Search for a book by keyword");
            menuOptions.Add("4. Return a checked-out book");
            menuOptions.Add("5. Donate a book to the Library");
            menuOptions.Add("6. Leave Library");

            List<Book> books = TextEdit.ReadFile("library.txt");
            bool keepReading = true;
            while (keepReading)
            {
                Console.WriteLine("\nMain Menu:\n");
                Library.DisplayMainMenu(menuOptions);
                keepReading = Validator.GetUserChoice("Please select an option from the list above: ", menuOptions, books);
            }

            TextEdit.StoreBooksToFile(books);
            Console.WriteLine("\nGoodbye!");
            Console.ReadLine();
        }
    }
}
