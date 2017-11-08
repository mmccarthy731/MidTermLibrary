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
                Console.WriteLine("\n1. View all books\n2. Search for a book by author\n3. Search for a book by keyword\n4. Return a checked-out book\n5. Leave library\n");
                Console.Write("Please select an option from the list above: ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    DisplayBooks(books);
                    GetBook(books);
                    keepReading = DoAgain();
                }
                else if (input == "2")
                {
                    Console.Write("\nPlease enter the author's name (first, last or both): ");
                    string authorInput = Console.ReadLine().ToLower();
                    Console.WriteLine($"\n{"#",-5}{"Book Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}");
                    Console.WriteLine("==========================================================================================");
                    int matches = 0;
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].Author.ToLower().Contains(authorInput))
                        {
                            matches++;
                            Console.WriteLine(books[i].ToString());
                        }

                    }
                    if (matches == 0)
                    {
                        Console.WriteLine("We could not locate any books by the specified author.");
                    }
                    else
                    {
                        GetBook(books);
                    }
                    keepReading = DoAgain();
                }
                else if (input == "3")
                {
                    Console.Write("\nPlease enter a keyword to search by: ");
                    string keyInput = Console.ReadLine().ToLower();
                    Console.WriteLine($"\n{"#",-5}{"Book Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}");
                    Console.WriteLine("==========================================================================================");
                    int matches = 0;
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].Name.ToLower().Contains(keyInput))
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
                        GetBook(books);
                    }
                    keepReading = DoAgain();
                }
                else if (input == "4")
                {
                    ReturnBook(books);
                    keepReading = DoAgain();
                }
                else if (input == "5")
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

        public static void DisplayBooks(List<Book> books)
        {
            Console.WriteLine($"\n{"#",-5}{"Book Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}");
            Console.WriteLine("==========================================================================================");
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{(i + 1) + ":", -5}" + books[i].ToString());
            }
        }

        public static void GetBook(List<Book> books)
        {
            Console.Write($"\nWhich book would you like to select? (1 - {books.Count}): ");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int num);
            while(!success || num < 1 || num > books.Count)
            {
                Console.Write($"\nInvalid input. Please select a book number (1 - {books.Count}): ");
                success = int.TryParse(Console.ReadLine(), out num);
            }
            int index = num - 1;

            CheckedOutBook checkedOutBook = new CheckedOutBook(books[index].Name, books[index].Author, StatusEnum.CheckedOut);
            books.RemoveAt(index);
            books.Insert(index, checkedOutBook);
            checkedOutBook.DueDate = CheckedOutBook.GetDueDate();
        }

        public static void ReturnBook(List<Book> books)
        {
            DisplayBooks(books);
            Console.Write($"\nWhat is the book number for the book you are returning? (1 - {books.Count}): ");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int num);
            while (!success || num < 1 || num > books.Count)
            {
                Console.Write($"\nInvalid input. Please select a book number for your return (1 - {books.Count}): ");
                success = int.TryParse(Console.ReadLine(), out num);
            }
            int index = num - 1;

            Book book = new Book(books[index].Name, books[index].Author, StatusEnum.OnShelf);
            books.RemoveAt(index);
            books.Insert(index, book);
        }

        public static bool DoAgain()
        {
            bool doAgain = false;
            bool valid = false;
            while (!valid)
            {
                Console.Write("Would you like to keep reading? (Y or N): ");
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
