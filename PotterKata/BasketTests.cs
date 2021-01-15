using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestStack.BDDfy;

namespace PotterKata
{
    [TestFixture]
    public class BasketTests
    {
        private Basket _subject;

        [Test]
        public void AddingItemsToBasket()
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(new Book()))
                .Then(_ => Basket_Is_Not_Empty())
                .BDDfy();
        }

        private void An_Empty_Basket()
        {
            _subject = Basket.Create();
        }

        private void Book_Is_Added_To_Basket(Book book)
        {
            _subject.AddBook(book);
        }

        private void Basket_Is_Not_Empty()
        {
            Assert.That(_subject.BasketItems, Is.Not.Empty);
        }
    }

    public class Book
    {
    }

    public class Basket
    {
        private Basket()
        {
            this.BasketItems = new List<Book>();
        }
        
        public static Basket Create()
        {
            return new Basket();
        }

        public void AddBook(Book book)
        {
            BasketItems.Add(book);
        }
        
        public List<Book> BasketItems { get; }
    }
}