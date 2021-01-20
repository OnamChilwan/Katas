using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PotterKata.Enums;
using PotterKata.Models;
using TestStack.BDDfy;

namespace PotterKata
{
    [TestFixture]
    public class BasketTests
    {
        private Basket _subject;

        [Test]
        public void BuyingTwoBooksBuyOneGetOneFreeOffer()
        {
            var book = new Book(Volumes.Chamber_of_Secrets);
            
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(book))
                .And(_ => Buy_One_Get_One_Free_Offer_Is_Applied())
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Contains_The_Correct_Number_Of_Book_Sets(2))
                .And(_ => Each_BookSet_Contains_The_Correct_Number_Books(1))
                .And(_ => Basket_Total_Is(8))
                .BDDfy();
        }
        
        [Test]
        public void AddingMultipleDifferentBooksToBasket()
        {
            var books = new List<Book>
            {
                new Book(Volumes.Philosophers_Stone),
                new Book(Volumes.Chamber_of_Secrets),
                new Book(Volumes.Philosophers_Stone),
                new Book(Volumes.Chamber_of_Secrets),
            };
            
            this.Given(_ => An_Empty_Basket())
                .When(_ => Books_Are_Added_To_Basket(books))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Contains_The_Correct_Number_Of_Book_Sets(2))
                .And(_ => Each_BookSet_Contains_The_Correct_Number_Books(2))
                .BDDfy();
        }

        [Test]
        public void AddingSameBookTwiceToBasket()
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(new Book(Volumes.Philosophers_Stone)))
                .And(_ => Book_Is_Added_To_Basket(new Book(Volumes.Philosophers_Stone)))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Contains_The_Correct_Number_Of_Book_Sets(2))
                .And(_ => Each_BookSet_Contains_The_Correct_Number_Books(1))
                .BDDfy();
        }

        [TestCaseSource(typeof(TestData))]
        public void AddingVaryingBooksFromTheSeries(List<Book> books, double expectedCost)
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Books_Are_Added_To_Basket(books))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Total_Is(expectedCost))
                .BDDfy();
        }

        class TestData : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetBooks(8,Volumes.Philosophers_Stone);
                yield return GetBooks(15.2, Volumes.Philosophers_Stone, Volumes.Chamber_of_Secrets);
                yield return GetBooks(21.6, Volumes.Philosophers_Stone, Volumes.Chamber_of_Secrets, Volumes.Prisoner_of_Azkaban);
                yield return GetBooks(25.6, Volumes.Philosophers_Stone, Volumes.Chamber_of_Secrets, Volumes.Prisoner_of_Azkaban, Volumes.Goblet_of_Fire);
                yield return GetBooks(30, Volumes.Philosophers_Stone, Volumes.Chamber_of_Secrets, Volumes.Prisoner_of_Azkaban, Volumes.Goblet_of_Fire, Volumes.Order_of_the_Phoenix);
                yield return GetBooks(16, Volumes.Philosophers_Stone, Volumes.Philosophers_Stone);
                yield return GetBooks(23.2, Volumes.Philosophers_Stone, Volumes.Philosophers_Stone, Volumes.Chamber_of_Secrets);
                yield return GetBooks(51.2, Volumes.Philosophers_Stone, Volumes.Philosophers_Stone, Volumes.Chamber_of_Secrets, Volumes.Chamber_of_Secrets, Volumes.Prisoner_of_Azkaban, Volumes.Prisoner_of_Azkaban, Volumes.Goblet_of_Fire, Volumes.Order_of_the_Phoenix);
            }

            private static object[] GetBooks(double expectedCost, params Volumes[] series)
            {
                return new object[] { series.Select(i => new Book(i)).ToList(), expectedCost };
            }
        }

        private void An_Empty_Basket()
        {
            _subject = Basket.Create();
        }

        private void Book_Is_Added_To_Basket(Book book)
        {
            _subject.AddBook(book);
        }

        private void Buy_One_Get_One_Free_Offer_Is_Applied()
        {
            _subject.ApplyOffer();
        }

        private void Basket_Is_Not_Empty()
        {
            Assert.That(_subject.BasketItems, Is.Not.Empty);
        }

        private void Books_Are_Added_To_Basket(IEnumerable<Book> books)
        {
            _subject.AddBooks(books);
        }

        private void Each_BookSet_Contains_The_Correct_Number_Books(int numberOfBooks)
        {
            foreach (var item in _subject.BasketItems)
            {
                Assert.That(item.Books.Count, Is.EqualTo(numberOfBooks));
            }
        }

        private void Basket_Contains_The_Correct_Number_Of_Book_Sets(int numberOfItems)
        {
            Assert.That(_subject.BasketItems.Count, Is.EqualTo(numberOfItems));
        }

        private void Basket_Total_Is(double expectedTotal)
        {
            Assert.That(_subject.Total, Is.EqualTo(expectedTotal), () =>
            {
                // TODO: instead of this look into implementing List<T> and override ToString() for better test output. This is awful */
                var builder = new StringBuilder();
                
                foreach (var basketItem in _subject.BasketItems)
                {
                    builder.Append("Book Set: ");
                    
                    foreach (var book in basketItem.Books)
                    {
                        builder.Append($"{book},");
                    }
                    
                    builder.AppendLine();
                }

                return builder.ToString();
            });
        }
    }
}