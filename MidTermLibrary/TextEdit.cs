using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class TextEdit
    {
        private static StreamReader readFromFILENAME;
        private static StreamWriter writeToFILENAME;

        //Option to read entire file
        public static List<Book> ReadLibrary(string FILENAME)
        {
            List<Book> books = new List<Book>();

            //if (!File.Exists(FILENAME))
            //{
            //    FileStream newfile = File.Create(FILENAME);
            //    newfile.Close();
            //}
            //
            //// check file exists end .............
            readFromFILENAME = new StreamReader(FILENAME);

            while (true)
            {
                string line = readFromFILENAME.ReadLine();

                if (line == null || line == "")
                {
                    break;
                }

                string[] words = line.Split('|');

                if (words.Length != 7)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }

                string name = words[0];

                string author = words[1];

                bool success = int.TryParse(words[2], out int index);
                if (!success)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }
                StatusEnum status = (StatusEnum)index;

                string user = words[3];

                string dueDate = words[4];

                bool success3 = int.TryParse(words[5], out int total);
                if(!success3)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }
                int totalScore = total;

                bool success4 = int.TryParse(words[6], out int number);
                if(!success4)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }
                int numberOfRatings = number;

                books.Add(new Book(name, author, status, user, dueDate, totalScore, numberOfRatings));
            }
            readFromFILENAME.Close();
            return books;
        }

        public static List<User> ReadUsers(string filename)
        {
            List<User> users = new List<User>();

            readFromFILENAME = new StreamReader(filename);

            while (true)
            {
                string line = readFromFILENAME.ReadLine();

                if (line == null || line == "")
                {
                    break;
                }

                string[] words = line.Split('|');

                if (words.Length != 3)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }

                string name = words[0];

                bool success = int.TryParse(words[1], out int pinNumber);
                if (!success)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }
                int pin = pinNumber;

                bool success2 = int.TryParse(words[2], out int number);
                if (!success2)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }
                int numberOfBooks = number;

                users.Add(new User(name, pin, numberOfBooks));
            }
            readFromFILENAME.Close();
            return users;
        }

        public static void WriteLibrary(List<Book> books)
        {
            //Make a new write stream and append data
            writeToFILENAME = new StreamWriter("../../library.txt", false);

            foreach (Book book in books)
            {
                writeToFILENAME.WriteLine($"{book.Name}|{book.Author}|{(int)book.Status}|{book.User}|{book.DueDate}|{book.TotalScore}|{book.NumberOfRatings}");
            }

            writeToFILENAME.Close();
        }

        public static void WriteUsers(List<User> users)
        {
            writeToFILENAME = new StreamWriter("../../users.txt", false);

            foreach(User user in users)
            {
                writeToFILENAME.WriteLine($"{user.Name}|{user.Pin}|{user.NumberOfBooks}");
            }

            writeToFILENAME.Close();
        }
    }
}