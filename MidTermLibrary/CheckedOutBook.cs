using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class CheckedOutBook : Book
    {
        private string dueDate;

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public CheckedOutBook(string name, string author, StatusEnum status)
            : base(name, author, status)
        {

        }

        public static string GetDueDate()
        {
            DateTime checkoutDate = DateTime.Today;
            return checkoutDate.AddDays(14).ToShortDateString();
            
        }

        public override string ToString()
        {
            return $"{Name,-35}{Author,-25}{Status,-10}{DueDate, 15}";
        }
    }
}
