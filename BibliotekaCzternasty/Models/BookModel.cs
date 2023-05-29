using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCzternasty.Models
{
    public  class BookModel
    {
        public  int Id { get; set; }
        public  string Title { get; set; }
        public  string Author { get; set; }
        public  string Category { get; set; }
        public bool IsLoaned { get; set; } = false;

        public void DisplayBookData()
        {
            Console.WriteLine($"Title:\"{Title}\"\nAuthor: {Author}\nCategory: {Category}\nIsLoaned: {IsLoaned}");
        }
    }
}
