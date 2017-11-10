using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class SearchOptions
    {
        public static void SearchByAuthor(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine($"\n{"#",-5}{"Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}{"Rating",15}");
            Console.WriteLine("=========================================================================================================");
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
                Library.CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
            }
        }

        public static void SearchByKeyword(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-10}{"Due Date",15}{"Rating",15}");
            Console.WriteLine("=========================================================================================================");
            int matches = 0;
            for (int i = 0; i < books.Count; i++)
            {
                string[] words = books[i].Name.Split(' ');
                for(int j = 0; j < words.Length; j++)
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
                Console.WriteLine("None of our books contained the key word you searched.");
            }
            else
            {
                Library.CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
            }
        }

        public static void SearchByRating(string prompt, List<Book> books)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int rating);
            while(!success || rating < 0 || rating > 5)
            {
                Console.Write("Invalid input. Please select a rating between 0 and 5 stars: ");
                success = int.TryParse(Console.ReadLine(), out rating);
            }
            int matches = 0;
            for(int i = 0; i < books.Count; i++)
            {
                if(books[i].AvgRating >= rating)
                {
                    matches++;
                    Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
                }
            }
            if(matches == 0)
            {
                Console.WriteLine($"We do not currently have any books rated at or over {rating} stars.");
            }
            else
            {
                Library.CheckoutBook($"\nWhich book would you like to select? (Enter book ID# (1 - {books.Count}) or enter 0 to return to the Main Menu): ", books);
            }
        }
    }
}
