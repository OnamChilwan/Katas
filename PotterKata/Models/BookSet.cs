using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class BookSet
    {
        public List<Book> Books { get; }

        public BookSetPrice Price { get; }
        
        private BookSet()
        {
            Books = new List<Book>();
            Price = new BookSetPrice(Books);
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
            return Books.Any(x => x.Volume == book.Volume);
        }
    }
}