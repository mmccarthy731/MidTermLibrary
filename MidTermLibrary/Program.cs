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
            List<Book> books = new List<Book>();

            books.Add(new Book("The Odyssey", "Homer", StatusEnum.OnShelf));
            books.Add(new Book("1984", "George Orwell", StatusEnum.OnShelf));
            books.Add(new Book("New Moon", "Stephenie Meyer", StatusEnum.OnShelf));
            books.Add(new Book("Life of Pi", "Yann Martel", StatusEnum.OnShelf));
            books.Add(new Book("Brave New World", "Aldous Huxley", StatusEnum.OnShelf));
            books.Add(new Book("Breaking Dawn", "Stephenie Meyer", StatusEnum.OnShelf));
            books.Add(new Book("The Time Traveler's Wife", "Audrey Niffenegger", StatusEnum.OnShelf));
            books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", StatusEnum.OnShelf));
            books.Add(new Book("Game of Thrones", "George R.R. Martin", StatusEnum.OnShelf));
            books.Add(new Book("The Iliad", "Homer", StatusEnum.OnShelf));
            books.Add(new Book("The Scarlet Letter", "Nathaniel Hawthorne", StatusEnum.OnShelf));
            books.Add(new Book("The Adventures of Tom Sawyer", "Mark Twain", StatusEnum.OnShelf));
            books.Add(new Book("War and Peace", "Leo Tolstoy", StatusEnum.OnShelf));
            books.Add(new Book("Macbeth", "William Shakespeare", StatusEnum.OnShelf));
            books.Add(new Book("Romeo and Juliet", "William Shakespeare", StatusEnum.OnShelf));

            bool keepReading = true;
            while (keepReading)
            {
                Console.WriteLine("\nMain Menu:\n\n1. View all books\n2. Search for a book by author\n3. Search for a book by keyword\n4. Return a checked-out book\n5. Add a book to the text log of books.\n6. Leave library\n");
                Console.Write("Please select an option from the list above: ");
                string input = Console.ReadLine();
                if (input == "1") // Display all books
                {
                    Library.DisplayBooks(books);
                    Library.CheckoutBook($"\nWhich book would you like to select? (Enter 1 - {books.Count} or \"M\" to return to the Main Menu): ", books);
                    keepReading = true;
                }
                else if (input == "2") //Search by Author
                {
                    Library.SearchByAuthor("\nPlease enter the author's name (first, last or both): ", books);
                    keepReading = true;
                }
                else if (input == "3") //Search by Keyword
                {
                    Library.SearchByKeyword("\nPlease enter a keyword to search by: ", books);
                    keepReading = true;
                }
                else if (input == "4") //Return books
                {
                    Library.DisplayBooks(books);
                    Library.ReturnBook($"\nPlease enter the book ID# for your return (1 - {books.Count}) or \"M\" to return to the Main Menu): ", books);
                    keepReading = true;
                }
                else if (input == "5")
                {
                    Console.WriteLine("Add a book to the text log of books.");
                    TextEdit.WriteBookToFile(books);
                }
                else if (input == "6") //Exit Program
                {
                    keepReading = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid input.\n");
                    keepReading = true;
                }
            }
            Console.WriteLine("\nGoodbye!");
            Console.ReadLine();
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
