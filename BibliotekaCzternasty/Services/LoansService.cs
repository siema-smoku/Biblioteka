using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaCzternasty.Models;

namespace BibliotekaCzternasty.Services
{
    public class LoansService : ILoansService
    {
        public LoanDetailsModel CreateLoan(BookModel book, int lastId)
        {
            var startLoan = DateTime.Today;
            Console.Write($"For how lond you you want to loan \"{book.Title}\" by {book.Author}: ");
            var daysToLoan = Convert.ToInt32(Console.ReadLine());
            var endLoan = startLoan.AddDays(daysToLoan);
            book.IsLoaned = true;
            return new LoanDetailsModel(lastId + 1, book, startLoan, endLoan, daysToLoan);
        }
    }
}
