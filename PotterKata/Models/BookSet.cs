using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class BookSet
    {
        public List<Book> Books { get; }

        private BookSet()
        {
            Books = new List<Book>();
        }
        
        public static BookSet Create()
        {
            return new BookSet();
        }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }

        public bool Contains(Book book)
        {
            return Books.Any(x => x.Series == book.Series);
        }
    }
}