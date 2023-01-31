using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso_linq
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\jdaguilar\\Desktop\\juan diego\\Estudio\\C#\\LINQ\\CursoLINQ\\curso-linq\\books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
       
        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }
        public IEnumerable<Book> BooksAfter2000() 
        {//extension method
            //return librosCollection.Where(book => book.PublishedDate.Year > 2000);
            
            //query expression
            return from book in librosCollection where book.PublishedDate.Year > 2000
                select book;
        }
        // books must contain 250 pages and the title the words in Action
        public IEnumerable<Book> Books250pagesInAction()
        {
            //extension method
            //return librosCollection.Where(book => book.Title.Contains("in Action") && book.PageCount > 250);

            //Query expression
            return from book in librosCollection
                where book.Title.Contains("in Action") && book.PageCount > 250
                select book;
        }

        public bool AllBooksHaveStatus()
        {
            //extension method
            return librosCollection.All(p => p.Status != string.Empty);
        }

        public bool BookPublishedIn2005() 
        {
            return librosCollection.Any(book => book.PublishedDate.Year == 2005);
        }


        public IEnumerable<Book> BooksPythonCategory() 
        { //extension method
            //return librosCollection.Where(book => book.Categories.Contains("Python"));

            //query method 
            return from book in librosCollection where book.Categories.Contains("Python") select book;
        }

        public IEnumerable<Book> BooksOrderbyName() 
        { // extension method
            return librosCollection.Where(book => book.Categories.Contains("Java")).OrderBy(title => title.Title);
        }

        public IEnumerable<Book> BooksOrderbyPages()
        {
            return librosCollection.Where(book => book.PageCount > 450).OrderByDescending(book => book.PageCount);
        }

        public IEnumerable<Book> OperatorTake()
        {
            return librosCollection.Where(book => book.Categories.Contains("Java"))
                .OrderByDescending(book => book.PublishedDate).Take (3);
        }

        public IEnumerable<Book> OperatorSkip()
        {
            return librosCollection.Where(book => book.PageCount > 400).Skip(2).Take(2);
        }

        public IEnumerable<Book> OperatorSelect() 
        {
             return librosCollection.Take(3).Select(book => new  Book() {
                    Title = book.Title,
                    PageCount = book.PageCount
            });
        }

        public int OperatorCount()
        {
            return librosCollection.Count(book => book.PageCount >= 200 && book.PageCount <= 500);
        }

        public DateTime MostOldBook()
        {
            return librosCollection.Min(book => book.PublishedDate);
        }


        public int MostPagesMax()
        {
            return librosCollection.Max(book => book.PageCount);
        }

        public Book OpertatorMinby()
        {
            return librosCollection.Where(book => book.PageCount > 0).MinBy(page => page.PageCount);
        }

        public Book OpertatorMaxby()
        {
            return librosCollection.MaxBy(book => book.PublishedDate);
        }

        public int OpertatorSum()
        {
            return librosCollection.Where(book => book.PageCount > 0 && book.PageCount <= 500).Sum(book => book.PageCount);
        }

        public string OperatorAggregate()
        {
            return librosCollection.Where(book => book.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
            {
                if (TitulosLibros != string.Empty)
                {
                    TitulosLibros += " - " + next.Title;
                }
                else
                {
                    TitulosLibros += next.Title;
                }

                return TitulosLibros;
            });
        }


        public double OperatorAverage()
        {
            return librosCollection.Average(book => book.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> OperatorGroupby()
        {
            return librosCollection.Where(book => book.PublishedDate.Year >= 2000).GroupBy(book => book.PublishedDate.Year);
        }

        public ILookup<char, Book> OperatorLookup()
        {
            return librosCollection.ToLookup(book => book.Title[0], book => book);
        }


        public IEnumerable<Book> BooksWithMoreThan2005withMoreThan500pages()
        {
            var booksAfter2005 = librosCollection.Where(book => book.PublishedDate.Year > 2005);

            var bookMore500pages = librosCollection.Where(book => book.PageCount > 500);

            return booksAfter2005.Join(bookMore500pages, book1 => book1.Title, book2 => book2.Title,
                (book1, book2) => book1);

        }
    }
}

