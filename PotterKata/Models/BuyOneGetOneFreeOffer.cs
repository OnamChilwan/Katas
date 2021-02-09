namespace PotterKata.Models
{
    public class BuyOneGetOneFreeOffer
    {
        public BookSets Execute(BookSets bookSets)
        {
            var copy = new BookSets(bookSets);
    
            foreach (var bookSet in bookSets)
            {
                foreach (var book in bookSet.Books)
                {
                    copy.Add(new Book(book.Volume, 0));
                }
            }

            return copy;
        }
    }
}