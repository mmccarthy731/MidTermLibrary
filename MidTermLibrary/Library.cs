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
            if (input.ToLower() != "m")
            {
                bool success = int.TryParse(input, out int num);
                while (!success || num < 1 || num > books.Count)
                {
                    Console.Write($"\nInvalid input. Please enter a book number (Enter book ID# (1 - {books.Count}) or \"M\" to return to the Main Menu): ");
                    success = int.TryParse(Console.ReadLine(), out num);
                }
                int index = num - 1;
                if (books[index].Status == StatusEnum.CheckedOut)
                {
                    Console.WriteLine($"\nI am sorry, {books[index].Name} is checked out and is due back on {books[index].DueDate}.");
                }
                else
                {
                    if (Program.GetYesOrNo($"\nYou have selected {books[index].Name}. Would you like to check out this book? (Y or N): "))
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
            if (input.ToLower() != "m")
            {
                bool success = int.TryParse(input, out int num);
                while (!success || num < 1 || num > books.Count)
                {
                    Console.Write($"\nInvalid input. Please enter the book ID# for your return (1 - {books.Count}): ");
                    success = int.TryParse(Console.ReadLine(), out num);
                }
                int index = num - 1;
                if (books[index].Status == StatusEnum.OnShelf)
                {
                    Console.WriteLine($"\nSorry, our records indicate that our copy {books[index].Name} has not been checked out.");
                }
                else
                {
                    if (Program.GetYesOrNo($"\nWould you like to return {books[index].Name}? (Y or N): "))
                    {
                        books[index].Status = StatusEnum.OnShelf;
                        books[index].DueDate = null;
                    }
                }
            }
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
                CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or \"M\" to return to the Main Menu): ", books);
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
                CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or \"M\" to return to the Main Menu): ", books);
            }
        }
    }
}
