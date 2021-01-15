using System.Collections.Generic;

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
    }
}