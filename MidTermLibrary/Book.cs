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

        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        private string dueDate;

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private int totalScore;

        public int TotalScore
        {
            get { return totalScore; }
            set { totalScore = value; }
        }

        private int numberOfRatings;

        public int NumberOfRatings
        {
            get { return numberOfRatings; }
            set { numberOfRatings = value; }
        }

        public Book(string name, string author, StatusEnum status, string user, string dueDate, int totalScore, int numberOfRatings)
        {
            this.name = name;
            this.author = author;
            this.status = status;
            this.user = user;
            this.dueDate = dueDate;
            this.totalScore = totalScore;
            this.numberOfRatings = numberOfRatings;
        }

        public static string GetDueDate()
        {
            DateTime checkoutDate = DateTime.Today;
            return checkoutDate.AddDays(14).ToShortDateString();
        }

        public static int GetBookRating()
        {
            Console.Write("\nHow many stars would you rate this book? (0 - 5): ");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int rating);
            while (!success || rating < 0 || rating > 5)
            {
                Console.Write("\nInvalid input. Please enter a rating between 0 and 5: ");
                success = int.TryParse(Console.ReadLine(), out rating);
            }
            return rating;
        }

        public static double GetAvgRating(int totalScore, int numberOfRatings)
        {
            return (double)totalScore / numberOfRatings;
        }

        public override string ToString()
        {
            return $"{Name,-35}{Author,-25}{Status,-15}{User, -15}{DueDate,-15}{"",10}{Validator.ConvertToStars(GetAvgRating(totalScore, numberOfRatings)),-5}";
        }
    }
}
