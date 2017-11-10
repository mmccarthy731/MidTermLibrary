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
        public const string FILENAME = "library.txt";
        private static StreamReader readFromFILENAME;
        private static StreamWriter writeTOFILENAME;

        //Option to read entire file
        public static List<Book> ReadFile(string FILENAME)
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(FILENAME))
            {
                FileStream newfile = File.Create(FILENAME);
                newfile.Close();
            }
            // check file exists end .............

            readFromFILENAME = new StreamReader(FILENAME);

            while (true)
            {
                string line = readFromFILENAME.ReadLine();

                if (line == null || line == "")
                {
                    break;
                }

                string[] words = line.Split('|');

                if (words.Length != 5)
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

                string dueDate = words[3];

                bool success2 = double.TryParse(words[4], out double average);
                if (!success)
                {
                    Console.WriteLine("Error in file format. Line contents: " + line);
                    break;
                }
                double avgRating = average;

                books.Add(new Book(name, author, status, dueDate, avgRating));

            }
            readFromFILENAME.Close();
            return books;
        }

        public static void StoreBooksToFile(List<Book> books)
        {
            //Make a new write stream and append data
            writeTOFILENAME = new StreamWriter(FILENAME, false);

            foreach (Book book in books)
            {
                writeTOFILENAME.WriteLine($"{book.Name}|{book.Author}|{(int)book.Status}|{book.DueDate}|{book.AvgRating}");
            }
            writeTOFILENAME.Close();
        }
    }
}