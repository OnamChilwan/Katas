using System.Collections.Generic;
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
        public void AddingSingleBookToBasket()
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(new Book(HarryPotterSeries.Philosophers_Stone)))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Total_Is(8))
                .BDDfy();
        }

        [Test]
        public void AddingSameBookTwiceToBasket()
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(new Book(HarryPotterSeries.Philosophers_Stone)))
                .And(_ => Book_Is_Added_To_Basket(new Book(HarryPotterSeries.Philosophers_Stone)))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Contains_X_Number_Of_Book_Sets(2))
                .And(_ => Each_BookSet_Contains_X_Number_Books(1))
                .And(_ => Basket_Total_Is(16))
                .BDDfy();
        }

        [Test]
        public void AddingTwoDifferentBooksToBasket()
        {
            var books = new List<Book>
            {
                new Book(HarryPotterSeries.Philosophers_Stone),
                new Book(HarryPotterSeries.Chamber_of_Secrets)
            };
            this.Given(_ => An_Empty_Basket())
                .When(_ => Books_Are_Added_To_Basket(books))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Contains_X_Number_Of_Book_Sets(1))
                .And(_ => Each_BookSet_Contains_X_Number_Books(2))
                .And(_ => Basket_Total_Is(15.20))
                .BDDfy();
        }

        private void Basket_Is_Not_Empty()
        {
            Assert.That(_subject.BasketItems, Is.Not.Empty);
        }

        private void Each_BookSet_Contains_X_Number_Books(int numberOfBooks)
        {
            foreach (var item in _subject.BasketItems)
            {
                Assert.That(item.Books.Count, Is.EqualTo(numberOfBooks));
            }
        }

        private void Basket_Contains_X_Number_Of_Book_Sets(int numberOfItems)
        {
            Assert.That(_subject.BasketItems.Count, Is.EqualTo(numberOfItems));
        }

        private void An_Empty_Basket()
        {
            _subject = Basket.Create();
        }

        private void Book_Is_Added_To_Basket(Book book)
        {
            _subject.AddBook(book);
        }

        private void Books_Are_Added_To_Basket(IEnumerable<Book> books)
        {
            _subject.AddBooks(books);
        }

        private void Basket_Total_Is(double expectedTotal)
        {
            Assert.That(_subject.Total, Is.EqualTo(expectedTotal));
        }
    }
}