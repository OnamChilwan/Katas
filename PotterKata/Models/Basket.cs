using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class Basket
    {
        public List<BookSet> BasketItems { get; }
        
        public double Total => BasketItems.Sum(x => x.Price);

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
            if (TryDetermineCheapestBookSet(book, out BookSet bookSet))
            {
                bookSet.AddBook(book);
            }
            else
            {
                var newBookSet = BookSet.Create();
                newBookSet.AddBook(book);
                BasketItems.Add(newBookSet);
            }
        }

        public void AddBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }

        private bool TryDetermineCheapestBookSet(Book book, out BookSet cheapestBookSet)
        {
            cheapestBookSet = null;

            foreach (var bookSet in BasketItems)
            {
                if (bookSet.Contains(book) || bookSet.Price > cheapestBookSet?.Price)
                {
                    continue;
                }

                cheapestBookSet = bookSet;
            }
            
            return cheapestBookSet != null;
        }
    }
}