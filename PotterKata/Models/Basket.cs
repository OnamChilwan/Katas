using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class Basket
    {
        private bool _buyOneGetOneFreeApplied;
        public List<BookSet> BasketItems { get; }
        
        public double Total
        {
            get
            {
                var total = BasketItems.Sum(bookSet => bookSet.Price.TotalIncDiscount);

                if (_buyOneGetOneFreeApplied)
                {
                    total = total / 2;
                }
                
                return total;
            }
        }

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

        public void ApplyOffer()
        {
            _buyOneGetOneFreeApplied = true;
            var copy = new List<BookSet>(BasketItems);
            
            for (var i = 0; i< copy.Count; i++)
            {
                foreach (var book in copy[i].Books)
                {
                    AddBook(book);
                }
            }
        }

        private bool TryDetermineCheapestBookSet(Book book, out BookSet cheapestBookSet)
        {
            cheapestBookSet = null;

            foreach (var bookSet in BasketItems)
            {
                if (bookSet.Contains(book) || bookSet.Price.IsMoreExpensive(cheapestBookSet?.Price))
                {
                    continue;
                }

                cheapestBookSet = bookSet;
            }
            
            return cheapestBookSet != null;
        }
    }
}