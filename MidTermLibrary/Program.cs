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
            Console.WriteLine("Weclome to the jungle.");
            List<Book> books = new List<Book>();
            List<string> menuOptions = new List<string>();

            menuOptions.Add("1. View all books");
            menuOptions.Add("2. Search for a book by author");
            menuOptions.Add("3. Search for a book by keyword");
            menuOptions.Add("4. Return a checked-out book");
            menuOptions.Add("5. Donate a book to the Library");
            menuOptions.Add("6. Leave Library");

            books.Add(new Book("The Odyssey", "Homer", StatusEnum.OnShelf));
            books.Add(new Book("1984","George Orwell", StatusEnum.OnShelf));
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
                Console.WriteLine("\nMain Menu:\n");
                Library.DisplayMainMenu(menuOptions);
                keepReading = Validator.GetUserChoice("Please select an option from the list above: ", menuOptions, books);
            }
            Console.WriteLine("\nGoodbye!");
            Console.ReadLine();
        }
    }
}
