using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BibliotekaCzternasty.Models;
using BibliotekaCzternasty.Services;
using Newtonsoft.Json;

namespace BibliotekaCzternasty.Services
{
    public class MainService
    {
        private List<CategoryModel> categories;
        private List<BookModel> books;
        private List<LoanDetailsModel> loans;
        private List<ReceiptModel> receipts;

        private readonly string categoriesJsonPath = "categories.json";
        private readonly string booksJsonPath = "books.json";
        private readonly string loansJsonPath = "loans.json";
        private readonly string receiptsJsonPath = "receipts.json";

        private readonly ILoansService _loansService = new LoansService();
        private readonly IManageInformationService _informationService = new ManageInformationService();
        private readonly IReceiptService _receiptService = new ReceiptService();


        public void StartProgram()
        {
            LoadAllData();
            DisplayMenu();
            SaveAllData();
        }

        private void DisplayMenu()
        {
            DisplayHeader();
            DisplayOptions();
            Console.Write("| |Choose your option: ");
            var option = Convert.ToInt32(Console.ReadLine());
            HandleOption(option);
        }

        private void HandleOption(int option)
        {
            DisplayHeader();
            switch (option)
            {
                case 1:
                    DisplayHeader();
                    var chosenCategoryToLoan = _informationService.ChooseCategory(categories);
                    DisplayHeader();
                    var chosenBookToLoan = _informationService.ChooseBook(chosenCategoryToLoan, option);
                    DisplayHeader();
                    var loan = _loansService.CreateLoan(chosenBookToLoan, loans.Count);
                    loans.Add(loan);
                    DisplayHeader();
                    var receipt = _receiptService.CreateReceipt(loan, receipts.Count);
                    receipts.Add(receipt);
                    DisplayHeader();
                    Console.WriteLine(
                        $"You just loaned \"{loan.LoanedBook.Title}\" by {loan.LoanedBook.Author} until {loan.LoanEnd.ToShortDateString()}.");
                    Console.WriteLine($"This loan will cost: ${receipt.Price}. Nice reading :)");
                    break;
                case 2:
                    DisplayHeader();
                    var loanToReturn = _informationService.ChooseLoan(loans);
                    loanToReturn.LoanedBook.IsLoaned = false;
                    var bookIndex = books.FindIndex(b => b.Id == loanToReturn.LoanedBook.Id);
                    if (bookIndex!= -1)
                    {
                        books[bookIndex] = loanToReturn.LoanedBook;
                    }
                    loans = loans.Where(l => l.Id != loanToReturn.Id).ToList();
                    DisplayHeader();
                    Console.WriteLine($"Loan: {loanToReturn.Id} for \"{loanToReturn.LoanedBook.Title}\" has been returned!");
                    Console.WriteLine("Details of your receipt: ");
                    var receiptToRemove = receipts.Where(r => r.LoanDetails.Id == loanToReturn.Id).FirstOrDefault();
                    receiptToRemove.DisplayReceipt();
                    receipts = receipts.Where(r => r.LoanDetails.Id != receiptToRemove.Id).ToList();
                    break;
                case 3:
                    DisplayHeader();
                    var chosenCategoryToView = _informationService.ChooseCategory(categories);
                    DisplayHeader();
                    var chosenBookToView = _informationService.ChooseBook(chosenCategoryToView, option);
                    DisplayHeader();
                    chosenBookToView.DisplayBookData();
                    break;
                case 4:
                    DisplayHeader();
                    var findOption = _informationService.FindOption();
                    if (findOption == "Category")
                    {
                        DisplayHeader();
                        var categoryToFind = _informationService.ChooseCategory(categories);
                        DisplayHeader();
                        categoryToFind.DisplayCategory();
                    }
                    else if(findOption == "Book")
                    {
                        DisplayHeader();
                        Console.Write("What is the title of the book you want to view: ");
                        var bookTitleToFind = Console.ReadLine();
                        DisplayHeader();
                        _informationService.FindBookByName(books, bookTitleToFind);

                    }
                    else if (findOption == "Loan")
                    {
                        if (loans.Count==0)
                        {
                            DisplayHeader();
                            Console.WriteLine("There are no current loans to view.");
                        }
                        else
                        {
                            DisplayHeader();
                            var loanToFind = _informationService.ChooseLoan(loans);
                            DisplayHeader();
                            loanToFind.DisplayLoanDetails();
                        }
                    }
                    break;
                case 5:
                    DisplayHeader();
                    Console.WriteLine("| | Thank you for using our Online Library!");
                    break;
            }
        
        }

        public void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("| |==========| |==========| |");
            Console.WriteLine("| |  ONLINE  | |  LIBRARY | |");
            Console.WriteLine("| |==========| |==========| |");
            Console.WriteLine();
        }

        private void DisplayOptions()
        {
            Console.WriteLine("|1|. Loan a book.");
            Console.WriteLine("|2|. Return a book.");
            Console.WriteLine("|3|. Display a book.");
            Console.WriteLine("|4|. Find.");
            Console.WriteLine("|5|. Exit!");
        }

        private void LoadAllData()
        {
            var categoriesJson = File.ReadAllText(categoriesJsonPath);
            categories = JsonConvert.DeserializeObject<List<CategoryModel>>(categoriesJson);
            var booksJson = File.ReadAllText(booksJsonPath);
            books = JsonConvert.DeserializeObject<List<BookModel>>(booksJson);
            foreach (var categoryModel in categories)
            {
                foreach (var bookModel in books)
                {
                    if (bookModel.Category == categoryModel.Name)
                    {
                        categoryModel.BooksOfCategory.Add(bookModel);
                    }
                }
            }
            var loansJson = File.ReadAllText(loansJsonPath);
            loans = JsonConvert.DeserializeObject<List<LoanDetailsModel>>(loansJson);
            var receiptsJson = File.ReadAllText(receiptsJsonPath);
            receipts = JsonConvert.DeserializeObject<List<ReceiptModel>>(receiptsJson);
        }

        private void SaveAllData()
        {
            var booksJson = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(booksJsonPath, booksJson);
            var loansJson = JsonConvert.SerializeObject(loans, Formatting.Indented);
            File.WriteAllText(loansJsonPath, loansJson);
            var receiptsJson = JsonConvert.SerializeObject(receipts, Formatting.Indented);
            File.WriteAllText(receiptsJsonPath, receiptsJson);
        }
    }
}
