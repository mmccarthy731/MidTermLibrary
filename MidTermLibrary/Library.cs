﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Library
    {
        public static void AddDonatedBook(List<Book> books)
        {
            Console.Write("\nWhat is the name of the book? ");
            string book = Console.ReadLine();
            Console.Write($"\nWho is the author of {book}? ");
            string author = Console.ReadLine();
            books.Add(new Book(book, author, StatusEnum.OnShelf, null, null,0,0));
        }

        public static void CheckoutBook(string prompt, List<Book> books, User user)
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
                    Console.WriteLine($"\nWe're sorry, {books[index].Name} is currently checked out and is due back on {books[index].DueDate}.");
                }
                else
                {
                    if (Validator.GetYesOrNo($"\nYou have selected {books[index].Name}. Would you like to check out this book? (Y or N): "))
                    {
                        if (user.NumberOfBooks == 3)
                        {
                            Console.WriteLine("\nYou can only have 3 books checked out at a time. Please return a book before attemping to check out another.");
                        }
                        else
                        {
                            books[index].Status = StatusEnum.CheckedOut;
                            books[index].DueDate = Book.GetDueDate();
                            books[index].User = user.Name;
                            user.NumberOfBooks++;
                            Console.WriteLine($"\nThank you. Your book is due back on {books[index].DueDate}.");
                        }
                    }
                }
            }
        }

        public static void DisplayBooks(List<Book> books)
        {
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-15}{"User",-15}{"Due Date",-15}{"",10}{"Rating",-5}");
            Console.WriteLine("==============================================================================================================================");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
            }
        }

        public static void DisplayCheckedOutBooks(List<Book> books, User user)
        {
            Console.WriteLine($"\n{"ID#",-5}{"Title",-35}{"Author",-25}{"Status",-15}{"User",-15}{"Due Date",-15}{"",10}{"Rating",-5}");
            Console.WriteLine("==============================================================================================================================");
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Status == (StatusEnum)1 && books[i].User == user.Name)
                {
                    Console.WriteLine($"{(i + 1) + ":",-5}" + books[i].ToString());
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

        public static void GetMainMenu(List<string> menu)
        {
            menu.Add("1. View all books");
            menu.Add("2. Search for a book by author");
            menu.Add("3. Search for a book by keyword");
            menu.Add("4. Search for a book by rating");
            menu.Add("5. Return a checked-out book");
            menu.Add("6. Donate a book to the library");
            menu.Add("7. Leave library");
        }

        public static void ReturnBook(string prompt, List<Book> books, User user)
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
                    return;
                }
                else
                {
                    Console.WriteLine();
                    if (Validator.GetYesOrNo($"Would you like to return {books[index].Name}? (Y or N): "))
                    {
                        if (books[index].User == user.Name)
                        {
                            Console.WriteLine();
                            if (Validator.GetYesOrNo($"Would you like to rate {books[index].Name}? (Y or N): "))
                            {
                                books[index].TotalScore += Book.GetBookRating();
                                books[index].NumberOfRatings++;

                            }
                            books[index].Status = StatusEnum.OnShelf;
                            books[index].DueDate = null;
                            books[index].User = null;
                            user.NumberOfBooks--;
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, our record show that the book you have selected was not checked out with your account");
                        }
                    }
                }
            }
        }
    }
}
