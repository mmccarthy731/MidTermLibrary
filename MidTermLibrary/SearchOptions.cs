using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class SearchOptions
    {
        public static void SearchByAuthor(string prompt, List<Book> books, User user)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-15}{"User",-15}{"Due Date",-15}{"",10}{"Rating",-5}");
            Console.WriteLine("==============================================================================================================================");
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
                Library.CheckoutBook($"\nWhich book would you like to select? Enter book ID# or enter 0 to return to the Main Menu: ", books, user);
            }
        }

        public static void SearchByKeyword(string prompt, List<Book> books, User user)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-15}{"User",-15}{"Due Date",-15}{"",10}{"Rating",-5}");
            Console.WriteLine("==============================================================================================================================");
            int matches = 0;
            for (int i = 0; i < books.Count; i++)
            {
                string[] words = books[i].Name.Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].ToLower() == input)
                    {
                        matches++;
                        Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
                    }
                }
            }
            if (matches == 0)
            {
                Console.WriteLine("None of our books contained the keyword you searched.");
            }
            else
            {
                Library.CheckoutBook($"\nWhich book would you like to select? Enter book ID# or enter 0 to return to the Main Menu: ", books, user);
            }
        }

        public static void SearchByRating(string prompt, List<Book> books, User user)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int rating);
            while (!success || rating < 0 || rating > 5)
            {
                Console.Write("Invalid input. Please select a rating between 0 and 5 stars: ");
                success = int.TryParse(Console.ReadLine(), out rating);
            }
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-15}{"User",-15}{"Due Date",-15}{"",10}{"Rating",-5}");
            Console.WriteLine("==============================================================================================================================");
            int matches = 0;
            for (int i = 0; i < books.Count; i++)
            {
                double bookRating = Book.GetAvgRating(books[i].TotalScore, books[i].NumberOfRatings);
                if (rating >= (double)bookRating - 0.5)
                {
                    matches++;
                    Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
                }
            }
            if (matches == 0)
            {
                Console.WriteLine($"We do not currently have any books rated at or over {rating} stars.");
            }
            else
            {
                Library.CheckoutBook($"\nWhich book would you like to select? Enter book ID# or enter 0 to return to the Main Menu: ", books, user);
            }
        }
    }
}
