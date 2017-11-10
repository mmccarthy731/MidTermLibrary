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
        public const string MENUFILE = "menu.txt";
        private static StreamReader readFromFILENAME;
        private static StreamWriter writeTOFILENAME;
        //public string altcodes = "✰★";

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
                //bool success = int.TryParse(words[2], out int index);
                //if (!success)
                //{
                //    Console.WriteLine("Error in file format. Line contents: " + line);
                //    break;
                //}

                StatusEnum status = (StatusEnum)index;
                string dueDate = words[3];
                string rating = words[4];
                char[] stars = rating.ToCharArray();

                //books.Add(new Book(name, author, status, dueDate, rating));

            }

            CloseReadStream(readFromFILENAME);
            return books;
        }

        public static List<string> ReadMenu(string MENUFILE)
        {
            readFromFILENAME = new StreamReader(MENUFILE);

            List<string> menu = new List<string>();

            while (true)
            {
                string line = readFromFILENAME.ReadLine();

                if (line == null || line == "")
                {
                    break;
                }

                string menuOption = line;
                menu.Add(menuOption);
            }

            readFromFILENAME.Close();
            return menu;
        }

        public static void WriteMenu(List<string> menu)
        {
            writeTOFILENAME = new StreamWriter(MENUFILE, false);

            foreach (string s in menu)
            {
                writeTOFILENAME.WriteLine(s);
            }

            writeTOFILENAME.Close();

        }

        public static void StoreBooksToFile(List<Book> books)
        {
            //Make a new write stream and append data
            writeTOFILENAME = new StreamWriter(FILENAME, false);

            foreach (Book book in books)
            {
                writeTOFILENAME.WriteLine($"{book.Name}|{book.Author}|{(int)book.Status}|{book.DueDate}|{book.Rating}");

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