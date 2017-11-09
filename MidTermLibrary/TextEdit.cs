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
        //StreamReader read = new StreamReader(FILENAME);
        //StreamWriter write = new StreamWriter(FILENAME, true);
        private static StreamReader readFromFILENAME;
        private static StreamWriter writeTOFILENAME;

        private static string name = "Name";
        private static string author = "Author";
        private static StatusEnum status;
        private static string dueDate;


        public static void ReadFile()
        {

            Console.WriteLine("\nViewing entire library...");
            readFromFILENAME = new StreamReader(FILENAME);

            try
            {
                //Read each book in the file line-by-line
                string entireFile = readFromFILENAME.ReadToEnd();

                if (!readFromFILENAME.EndOfStream)
                {
                    return;
                }

                else
                {
                    //TODO: Take out debug log if this works
                    Console.WriteLine(entireFile);
                    CloseReadStream(readFromFILENAME);
                }

            }

            catch (SystemException e)
            {
                Console.WriteLine("\nSomething went wrong.");
                Console.WriteLine(e.Message + "\n");
            }

        }

        //Appending individual books
        public static void WriteBookToFile(List<Book> books)
        {

            Book book = new Book($"{name,-35}", $"{ author,-25 }", StatusEnum.OnShelf);

            writeTOFILENAME = new StreamWriter(FILENAME, true);

            //Garbage code
            //Console.WriteLine("Please write books in format as follows: " + book.ToString());

            Console.WriteLine("Begin entering in entries.");
            Console.WriteLine("\nType \"save\" if you wish to save and stop adding book entries.\nType \"reset\" if you wish to reset current record of books");

            //Loop through making entries until the user decides to quit
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    //TODO: Validation for input length?
                    //if (input.Length > Book.ToString().Length)
                    //{

                    //}

                    string[] split = input.Split('\t');

                    ////TODO: Validation for split
                    //if (split.Length < 1)
                    //{
                    //    Console.WriteLine("String must be in the correct format");
                    //    continue;
                    //}

                    //Join everything and place a tab between each element of the split
                    string output = string.Join("\t", split);

                    //Write our output to the last line in the file
                    writeTOFILENAME.WriteLine(output);

                    if (input == "save")
                    {
                        books.Add(book);
                        writeTOFILENAME.Close();
                        break;
                    }

                    else if (input == "reset")
                    {
                        CloseWriteStream(writeTOFILENAME);
                        StreamWriter reset = new StreamWriter(FILENAME, false);
                        CloseWriteStream(reset);
                        break;
                    }


                    else
                    {
                        continue;
                    }


                }

                catch (SystemException e)
                {
                    Console.WriteLine("\nSomething went wrong trying to write to file.");
                    Console.WriteLine(e.Message + "\n");
                    break;
                }
            }
        }

        public static void StoreBooksToFile(List<Book> book)
        {
            //Make a new write stream and append data
            writeTOFILENAME = new StreamWriter(FILENAME, true);
            writeTOFILENAME.WriteLine(book);
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