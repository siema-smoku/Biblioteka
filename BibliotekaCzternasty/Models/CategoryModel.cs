using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookModel> BooksOfCategory { get; set; }


        public void DisplayCategory()
        {
            Console.WriteLine($"{Name} category has {BooksOfCategory.Count} books in our library");
        }

        public void DisplayBooksInCategory()
        {
            foreach (var book in BooksOfCategory)
            {
                book.DisplayBookData();
            }
        }
    }
}
