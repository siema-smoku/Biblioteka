using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BibliotekaCzternasty.Models;

namespace BibliotekaCzternasty.Services
{
    public class ManageInformationService : IManageInformationService
    {
        private Dictionary<int, string> optionDictionary = new() { { 1, "Category" }, { 2, "Book" }, { 3, "Loan" } };

        public CategoryModel ChooseCategory(List<CategoryModel> categories)
        {
            var categoryDictionary = new Dictionary<int, CategoryModel>();
            Console.WriteLine("Book from which category would you like to loan: ");
            int counter = 1;
            foreach (var category in categories)
            {
                Console.WriteLine($"{counter}: {category.Name}");
                categoryDictionary.Add(counter, category);
                counter++;
            }
            Console.Write("Your choice (type index): ");
            var optionCategory = Convert.ToInt32(Console.ReadLine());
            return categoryDictionary[optionCategory];
        }

        public BookModel ChooseBook(CategoryModel category, int option)
        {
            var bookDictionary = new Dictionary<int, BookModel>();
            Console.WriteLine("What book you want to loan: ");
            var counter = 1;
            if (option == 1)
            {
                foreach (var book in category.BooksOfCategory)
                {
                    if (!book.IsLoaned)
                    {
                        Console.WriteLine($"{counter}: \"{book.Title}\"");
                        bookDictionary.Add(counter, book);
                        counter++;
                    }
                }
            }
            else
            {
                foreach (var book in category.BooksOfCategory)
                {
                    Console.WriteLine($"{counter}: \"{book.Title}\"");
                    bookDictionary.Add(counter, book);
                    counter++;
                }
            }

            Console.Write("Your choice (type index): ");
            var optionBook = Convert.ToInt32(Console.ReadLine());
            return bookDictionary[optionBook];
        }
        public LoanDetailsModel ChooseLoan(List<LoanDetailsModel> loans)
        {
            var loanDictionary = new Dictionary<int, LoanDetailsModel>();
            Console.WriteLine("What loan you want to display:");
            var counter = 1;
            foreach (var loan in loans)
            {
                Console.WriteLine($"{counter}. LoanId: {loan.Id} for \"{loan.LoanedBook.Title}\"");
                loanDictionary.Add(counter, loan);
                counter++;
            }
            Console.Write("Your choice (type index): ");
            var optionLoan = Convert.ToInt32(Console.ReadLine());
            return loanDictionary[optionLoan];
        }
        public string FindOption()
        {
            Console.WriteLine("1. Category");
            Console.WriteLine("2. Book");
            Console.WriteLine("3. Loan");
            Console.Write("What are you looking for (type index): ");
            var result = Convert.ToInt32(Console.ReadLine());
            return optionDictionary[result];
        }

        public void FindBookByName(List<BookModel> books, string title)
        {
            var bookFound = false;
            var book = new BookModel();
            foreach (var bookModel in books)
            {
                if (bookModel.Title.ToUpper() == title.ToUpper())
                {
                    book = bookModel;
                    bookFound = true;
                    break;
                }
            }
            if (!bookFound)
            {
                Console.WriteLine("There is no such book in our library :(");
            }
            else
            {
                book.DisplayBookData();
            }
        }
    }
}
