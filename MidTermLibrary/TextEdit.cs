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

        private const string FILENAME = "library.txt";
        private static StreamReader readFromFILENAME;
        private static StreamWriter writeTOFILENAME;

        //Option to read entire file
        public static List<Book> ReadFile(string FILENAME)
        {
            List<Book> books = new List<Book>();

            Console.WriteLine("\nViewing entire library...");
            //  check file exists start ........
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

                if (words.Length != 4)
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

                books.Add(new Book(name, author, status, dueDate));

            }

            CloseReadStream(readFromFILENAME);
            return books;
        }

        public static void StoreBooksToFile(List<Book> books)
        {
            //Make a new write stream and append data
            writeTOFILENAME = new StreamWriter(FILENAME, false);

            foreach (Book book in books)
            {
                writeTOFILENAME.WriteLine($"{book.Name}|{book.Author}|{(int)book.Status}|{book.DueDate}");

            }

            writeTOFILENAME.Close();
        }

        //Close write stream
        public static void CloseWriteStream(StreamWriter stream)
        {
            stream.Close();
        }

        //Close read stream
        public static void CloseReadStream(StreamReader stream)
        {
            stream.Close();
        }

    }
}