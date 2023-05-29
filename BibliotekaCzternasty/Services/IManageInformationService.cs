using BibliotekaCzternasty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Services
{
    public interface IManageInformationService
    {
        CategoryModel ChooseCategory(List<CategoryModel> catalogs);
        BookModel ChooseBook(CategoryModel category, int option);
        LoanDetailsModel ChooseLoan(List<LoanDetailsModel> loans);
        string FindOption();
        void FindBookByName(List<BookModel> books, string title);
    }
}
