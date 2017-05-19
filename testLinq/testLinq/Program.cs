using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testLinq
{
    class Book
    {
        public string NameBook { get; set; }
        public int Year { get; set; }
        public int ID { get; set; }
    }
     class Author
    {
        public string Name { get; set; }
        public int IDauthor { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book() { NameBook = "LINQ 1", Year = 1981, ID = 1 });
            books.Add(new Book() { NameBook = "LINQ book2", Year = 2016, ID =2 });
            books.Add(new Book() { NameBook = "Book3", Year = 1984, ID =3 });
            books.Add(new Book() { NameBook = "LINQ Book4", Year = 1652, ID =2 });
            List<Author> authors = new List<Author>();
            authors.Add(new Author() { Name = "First Author", IDauthor = 1 });
            authors.Add(new Author() { Name = "Second Author", IDauthor = 2 });
            authors.Add(new Author() { Name = "Third Author", IDauthor = 3 });


            //1
            Console.WriteLine(string.Join(" ",books.Where(x=> x.NameBook.Contains("LINQ"))
                                                    .Where(y=> y.Year%400==0|| y.Year%4==0 && y.Year%100 != 0)
                                                    .Select(z => $"{z.NameBook}-{z.Year}")));

            //2
            var result = books.Join(authors, b => b.ID,
                                              a => a.IDauthor,
                                              (b, a) => new { IDauthor = b.ID, NameBook = b.NameBook});
            
            var collection = result.GroupBy(c => c.IDauthor).Select(g => new {} );
            foreach (var item in collection)
            {

            }
            
        }
    }
}
