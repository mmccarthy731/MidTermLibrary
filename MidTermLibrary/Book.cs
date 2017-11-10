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
        private string author;
        private StatusEnum status;
        private string dueDate;
        private char[] rating;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public StatusEnum Status
        {
            get { return status; }
            set { status = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public char[] Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public Book(string name, string author, StatusEnum status, string dueDate, char[] rating)
        {
            this.name = name;
            this.author = author;
            this.status = status;
            this.dueDate = dueDate;
            this.rating = rating;
        }

        public static string GetDueDate()
        {
            DateTime checkoutDate = DateTime.Today;
            return checkoutDate.AddDays(14).ToShortDateString();
        }


        public override string ToString()
        {
            return $"{Name,-35}{Author,-25}{Status,-10}{DueDate,15}{Rating,10}";
        }
    }
}
