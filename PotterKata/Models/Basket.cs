using System.Collections.Generic;

namespace PotterKata.Models
{
    public class Basket
    {
        public BookSets BasketItems { get; private set; }

        public double Total => BasketItems.Total;

        private Basket()
        {
            this.BasketItems = new BookSets();
        }

        public static Basket Create()
        {
            return new Basket();
        }

        public void AddBook(Book book)
        {
            this.BasketItems.Add(book);
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
            BasketItems = new BuyOneGetOneFreeOffer().Execute(BasketItems);
        }
    }
}