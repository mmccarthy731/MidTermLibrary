using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Validator
    {
        public static bool GetUserChoice(string prompt, List<string> menuOptions, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int selection);
            while (!success || selection < 0 || selection > menuOptions.Count)
            {
                Console.Write("\nInvalid input. " + prompt);
                success = int.TryParse(Console.ReadLine(), out selection);
            }
            if(selection == 0)
            {
                return true;
            }
            else if (selection == 1)
            {
                Library.DisplayBooks(books);
                Library.CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
                return true;
            }
            else if (selection == 2)
            {
                Library.SearchByAuthor("\nPlease enter the author's name (first, last or both): ", books);
                return true;
            }
            else if (selection == 3)
            {
                Library.SearchByKeyword("\nPlease enter a keyword to search by: ", books);
                return true;
            }
            else if (selection == 4)
            {
                Library.DisplayBooks(books);
                Library.ReturnBook($"\nPlease enter the book ID# for your return (1 - {books.Count}) or 0 to return to the Main Menu): ", books);
                return true;
            }
            else if (selection == 5)
            {
                Library.AddDonatedBook(books);
                return true;
            }
            else if (selection == 6)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid input.\n");
                return true;
            }
        }

        public static bool GetYesOrNo(string prompt)
        {
            bool doAgain = false;
            bool valid = false;
            while (!valid)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    doAgain = true;
                    valid = true;
                }
                else if (input == "n" || input == "no")
                {
                    doAgain = false;
                    valid = true;
                }
                else
                {
                    Console.Write("Invalid input. ");
                    valid = false;
                }
            }
            return doAgain;
        }
    }
}
