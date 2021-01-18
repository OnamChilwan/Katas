using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class BookSetPrice
    {
        private readonly IEnumerable<Book> _books;

        public double TotalIncDiscount => CalculateTotal();
        
        public BookSetPrice(IEnumerable<Book> books)
        {
            _books = books;
        }

        public bool IsMoreExpensive(BookSetPrice price)
        {
            return this.TotalIncDiscount > price?.TotalIncDiscount ;
        }

        private double CalculateTotal()
        {
            const double costOfBook = 8;
            var discountRate = Discount.Create(_books.Count());
            return _books.Sum(x => costOfBook) * discountRate.Rate;
        }
    }
}