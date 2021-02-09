using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class BookSets : IEnumerable<BookSet>
    {
        private List<BookSet> _bookSets;

        public double Total => _bookSets.Sum(x => x.Price);

        public BookSets()
        {
            _bookSets = new List<BookSet>();
        }

        public BookSets(IEnumerable<BookSet> bookSets)
        {
            _bookSets = new List<BookSet>(bookSets);
        }
        
        public void Add(Book book)
        {
            if (TryDetermineCheapestBookSet(book, out BookSet bookSet))
            {
                bookSet.AddBook(book);
            }
            else
            {
                var newBookSet = BookSet.Create();
                newBookSet.AddBook(book);
                _bookSets.Add(newBookSet);
            }
        }

        public IEnumerator<BookSet> GetEnumerator()
        {
            return _bookSets.GetEnumerator();
        }

        private bool TryDetermineCheapestBookSet(Book book, out BookSet cheapestBookSet)
        {
            cheapestBookSet = null;

            foreach (var bookSet in _bookSets)
            {
                if (bookSet.Contains(book) || bookSet.Price > cheapestBookSet?.Price)
                {
                    continue;
                }

                cheapestBookSet = bookSet;
            }
            
            return cheapestBookSet != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}