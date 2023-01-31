namespace curso_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            LinqQueries queries = new LinqQueries();
            //All collections
            //PrintValues(queries.TodaLaColeccion());

            //Books post 2000
            //PrintValues(queries.BooksAfter2000());

            //Page count > 250 and title must contains in Action
            //PrintValues(queries.Books250pagesInAction());

            //all books have status
            //Console.WriteLine($"All books have status: {queries.AllBooksHaveStatus()}");

            //Search if a book or books have been published in 2005 return a bool
            //Console.WriteLine($"Have been any books published in 2005: {queries.BookPublishedIn2005()} ");

            //books that contains in categories python
            //PrintValues(queries.BooksPythonCategory());

            //Books that have the categorie of java and order by name
            //PrintValues(queries.BooksOrderbyName());

            //Books order by pages dsc
            //PrintValues(queries.BooksOrderbyPages());

            //First 3 books most recent and the categorie has to be Java
            //PrintValues(queries.OperatorTake());

            //thrid and fourth books with more than 400 pages
            //PrintValues(queries.OperatorSkip());

            //first three books filtred with select
            //PrintValues(queries.OperatorSelect());

            //count book with pages between 200 and 500
            //Console.WriteLine(queries.OperatorCount());

            //Oldest book by publish date
            //Console.WriteLine($"The oldest book by publish date is {queries.MostOldBook()}");

            //Count of most pages in a book
            //Console.WriteLine($"The biggest cant of pages in a book is {queries.MostPagesMax()}");

            ////book with the less pages
            //Book lessPages = queries.OpertatorMinby();
            //Console.WriteLine($"El libro con menos paginas es {lessPages.Title}");   

            //book with the most recent publish date
            //Book mostRecent = queries.OpertatorMaxby();
            //Console.WriteLine($"El libro mas reciente es {mostRecent.Title} \n y su fecha es {mostRecent.PublishedDate}");

            //sum of books  pages of 0 and 500
            //Console.WriteLine($"La suma de las paginas es {queries.OpertatorSum()}");

            //Concat al the book that are post 2015
            //Console.WriteLine($"Los libros son: \n {queries.OperatorAggregate()}");

            //Books Mod of chars of the title
            //Console.WriteLine($"The mod of the title chars is: {queries.OperatorAverage()}");

            //book published  in or after 2000
            //PrintGroup(queries.OperatorGroupby());

            //books who starts with a letter operator lookup
            //var dictionary = queries.OperatorLookup();
            //ImprimirDiccionario(dictionary, 'A');

            // operator join
            PrintValues(queries.BooksWithMoreThan2005withMoreThan500pages());
        }

        public static void PrintValues(IEnumerable<Book> booksList)
        {
            

            foreach (var book in booksList) 
            {
                Console.WriteLine("{0,-60} {1,9} {2,11}",book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }
        public static void PrintGroup(IEnumerable<IGrouping<int, Book>> ListadeLibros)
        {
            foreach (var grupo in ListadeLibros)
            {
                Console.WriteLine("");
                Console.WriteLine($"Grupo: {grupo.Key}");
                Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
                foreach (var item in grupo)
                {
                    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
                }
            }
        }

        public static void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var item in ListadeLibros[letra])
            {
                Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
            }
        }


    }
}