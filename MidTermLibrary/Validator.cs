using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Validator
    {
        public static string ConvertToStars(double rating)
        {
            if (rating < 0.5)
            {
                return "";
            }
            else if (rating < 1.5 && rating >= 0.5)
            {
                return "*";
            }
            else if (rating < 2.5 && rating >= 1.5)
            {
                return "**";
            }
            else if (rating < 3.5 && rating >= 2.5)
            {
                return "***";
            }
            else if (rating < 4.5 && rating >= 3.5)
            {
                return "****";
            }
            else
            {
                return "*****";
            }
        }

        public static bool GetUserChoice(string prompt, List<string> menuOptions, List<Book> books)
        {
            bool result = true;
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int selection);
            while (!success || selection < 1 || selection > menuOptions.Count)
            {
                Console.Write("\n\nInvalid input. " + prompt);
                success = int.TryParse(Console.ReadLine(), out selection);
            }

            switch (selection)
            {
                case 1:
                    Library.DisplayBooks(books);
                    Library.CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
                    break;
                case 2:
                    SearchOptions.SearchByAuthor("\nPlease enter the author's name (first, last or both): ", books);
                    break;
                case 3:
                    SearchOptions.SearchByKeyword("\nPlease enter a keyword to search by: ", books);
                    break;
                case 4:
                    SearchOptions.SearchByRating("\nPlease enter a minimum rating: (0 to 5 stars): ", books);
                    break;
                case 5:
                    Library.DisplayCheckedOutBooks(books);
                    Library.ReturnBook($"\nPlease enter the book ID# for your return or enter 0 to return to the Main Menu): ", books);
                    break;
                case 6:
                    Library.AddDonatedBook(books);
                    break;
                case 7:
                    result = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid input.\n");
                    break;
            }
            return result;
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
                    Console.Write("\nInvalid input. ");
                    valid = false;
                }
            }
            return doAgain;
        }
    }
}
