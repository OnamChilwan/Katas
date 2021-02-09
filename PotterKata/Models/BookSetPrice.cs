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

        private double CalculateTotal()
        {
            var discountRate = Discount.Create(_books.Count());
            return _books.Sum(x => x.Price) * discountRate.Rate;
        }
    }
}