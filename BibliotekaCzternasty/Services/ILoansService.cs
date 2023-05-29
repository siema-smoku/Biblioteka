using BibliotekaCzternasty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Services
{
    public interface ILoansService
    {
        LoanDetailsModel CreateLoan(BookModel book, int lastId);
    }
}
