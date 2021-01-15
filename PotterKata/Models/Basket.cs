using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class Basket
    {
        public List<BookSet> BasketItems { get; }
        
        public double Total => BasketItems.Sum(x => x.Books.Count * 8);

        private Basket()
        {
            this.BasketItems = new List<BookSet>();
        }

        public static Basket Create()
        {
            return new Basket();
        }

        public void AddBook(Book book)
        {
            BookSet bookSet = null;
            
            foreach (var item in BasketItems)
            {
                if (item.Contains(book))
                {
                    continue;
                }
                
                bookSet = item;
                break;
            }

            if (bookSet == null)
            {
                bookSet = BookSet.Create();
                BasketItems.Add(bookSet);
            }
            
            bookSet.AddBook(book);
        }

        public void AddBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }
    }
}