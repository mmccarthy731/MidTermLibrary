using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Book
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private StatusEnum status;

        public StatusEnum Status
        {
            get { return status; }
            set { status = value; }
        }

        private string dueDate;

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private double avgRating;

        public double AvgRating
        {
            get { return avgRating; }
            set { avgRating = value; }
        }

        private static int totalScore = 0;
        private static int numberOfRatings = 0;

        public Book(string name, string author, StatusEnum status, string dueDate, double avgRating)
        {
            this.name = name;
            this.author = author;
            this.status = status;
            this.dueDate = dueDate;
            this.avgRating = avgRating;
        }

        public static string GetDueDate()
        {
            DateTime checkoutDate = DateTime.Today;
            return checkoutDate.AddDays(14).ToShortDateString();
        }

        public static double GetBookRating()
        {
            Console.Write("\nHow many stars would you rate this book? (0 - 5): ");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int rating);
            while (!success || rating < 0 || rating > 5)
            {
                Console.Write("\nInvalid input. Please enter a rating between 0 and 5: ");
                success = int.TryParse(Console.ReadLine(), out rating);
            }
            totalScore += rating;
            numberOfRatings++;
            return (double)totalScore / numberOfRatings;
        }

        public override string ToString()
        {
            return $"{Name,-35}{Author,-25}{Status,-10}{DueDate,15}{Validator.ConvertToStars(AvgRating),15}";
        }
    }
}
