using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Models
{
    public class ReceiptModel
    {
        public int Id { get; set; }
        public LoanDetailsModel LoanDetails { get; set; }
        public double Price { get; set; }
        public ReceiptModel(int id, double price, LoanDetailsModel loanDetails)
        {
            Id = id;
            Price = price;
            LoanDetails = loanDetails;
        }

        public void DisplayReceipt()
        {
            Console.WriteLine($"ReceiptId: {Id}\nPrice: ${Price}\nLoanId: {LoanDetails.Id}");
        }
    }
}
