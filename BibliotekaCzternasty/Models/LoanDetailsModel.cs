using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Models
{
    public class LoanDetailsModel
    {
        public int Id { get; set; }
        public BookModel LoanedBook { get; set; }
        public DateTime LoanStart { get; set; }
        public DateTime LoanEnd { get; set; }
        public int LoanLength { get; set; }

        public LoanDetailsModel(int id, BookModel loanedBook, DateTime loanStart, DateTime loanEnd, int loanLength)
        {
            Id = id;
            LoanedBook = loanedBook;
            LoanStart = loanStart;
            LoanEnd = loanEnd;
            LoanLength = loanLength;
        }

        public void DisplayLoanDetails()
        {
            Console.WriteLine($"Loaned Book Title: {LoanedBook.Title}\nStarted: {LoanStart.ToShortDateString()}\nDaysLeft: {(LoanEnd-DateTime.Today).Days}\nPrice: ${LoanLength*0.5}");
        }
    }
}
