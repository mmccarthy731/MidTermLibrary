using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Library
    {
        public static void CheckoutBook(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int num);
            while (!success || num < 0 || num > books.Count)
            {
                Console.Write($"\nInvalid input. Please enter a book number (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ");
                success = int.TryParse(Console.ReadLine(), out num);
            }
            if (num != 0)
            {
                int index = num - 1;
                if (books[index].Status == StatusEnum.CheckedOut)
                {
                    Console.WriteLine($"\nWe're sorry, {books[index].Name} is checked out and is due back on {books[index].DueDate}.");
                }
                else
                {
                    if (Validator.GetYesOrNo($"\nYou have selected {books[index].Name}. Would you like to check out this book? (Y or N): "))
                    {
                        books[index].Status = StatusEnum.CheckedOut;
                        books[index].DueDate = Book.GetDueDate();
                        Console.WriteLine($"\nThank you. Your book is due back on {books[index].DueDate}.");
                    }
                }
            }
        }

        public static void DisplayBooks(List<Book> books)
        {
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}");
            Console.WriteLine("==========================================================================================");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
            }
        }

        public static void ReturnBook(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int num);
            while (!success || num < 0 || num > books.Count)
            {
                Console.Write($"\nInvalid input. Please enter the book ID# for your return (1 - {books.Count}), or enter 0 to return to the main menu: ");
                success = int.TryParse(Console.ReadLine(), out num);
            }
            if (num != 0)
            {
                int index = num - 1;
                if (books[index].Status == StatusEnum.OnShelf)
                {
                    Console.WriteLine($"\nWe apologize, our records indicate that our copy {books[index].Name} has not been checked out.");
                }
                else
                {
                    if (Validator.GetYesOrNo($"\nWould you like to return {books[index].Name}? (Y or N): "))
                    {
                        books[index].Status = StatusEnum.OnShelf;
                        books[index].DueDate = null;
                    }
                }
            }
        }

        public static void DisplayMainMenu(List<string> menu)
        {
            foreach (string line in menu)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        public static void AddDonatedBook(List<Book> books)
        {
            Console.Write("\nWhat is the name of the book? ");
            string book = Console.ReadLine();
            Console.Write($"\nWho is the author of {book}? ");
            string author = Console.ReadLine();
            books.Add(new Book(book, author, StatusEnum.OnShelf, null));

        }

        public static void SearchByAuthor(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine($"\n{"#",-5}{"Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}");
            Console.WriteLine("==========================================================================================");
            int matches = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.ToLower().Contains(input))
                {
                    matches++;
                    Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
                }
            }
            if (matches == 0)
            {
                Console.WriteLine("We could not locate any books by the specified author.");
            }
            else
            {
                CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
            }
        }

        public static void SearchByKeyword(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}");
            Console.WriteLine("==========================================================================================");
            int matches = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Name.ToLower().Contains(input))
                {
                    matches++;
                    Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
                }
            }
            if (matches == 0)
            {
                Console.WriteLine("None of our books contained the key word you searched.");
            }
            else
            {
                CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
            }
        }
    }
}
