using BibliotekaCzternasty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Services
{
    public class ReceiptService : IReceiptService
    {
        public ReceiptModel CreateReceipt(LoanDetailsModel loan, int lastId)
        {
            return new ReceiptModel(lastId + 1, loan.LoanLength*0.5, loan);
        }
    }
}
