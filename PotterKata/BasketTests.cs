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
        public void AddingSingleBookToBasket()
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(new Book(HarryPotterSeries.Philosophers_Stone)))
                .Then(_ => Basket_Is_Not_Empty())
                .BDDfy();
        }
        
        [Test]
        public void AddingSameBookTwiceToBasket()
        {
            this.Given(_ => An_Empty_Basket())
                .When(_ => Book_Is_Added_To_Basket(new Book(HarryPotterSeries.Philosophers_Stone)))
                .And(_ => Book_Is_Added_To_Basket(new Book(HarryPotterSeries.Philosophers_Stone)))
                .Then(_ => Basket_Is_Not_Empty())
                .And(_ => Basket_Contains_X_Number_Of_Items(2))
                .And(_ => Each_BookSet_Contains_X_Number_Books(1))
                .BDDfy();
        }

        private void Each_BookSet_Contains_X_Number_Books(int i)
        {
            foreach (var item in _subject.BasketItems)
            {
                Assert.That(item.Books.Count, Is.EqualTo(i));
            }
        }

        [Test]
        public void AddingMultipleDifferentBooksToBasket()
        {
            var books = new List<Book> { new Book(HarryPotterSeries.Philosophers_Stone), new Book(HarryPotterSeries.Chamber_of_Secrets) };
            this.Given(_ => An_Empty_Basket())
                .When(_ => Books_Are_Added_To_Basket(books))
                .Then(_ => Basket_Is_Not_Empty())
                .Then(_ => Basket_Contains_X_Number_Of_Items(1))
                .BDDfy();
        }

        private void Basket_Contains_X_Number_Of_Items(int numberOfItems)
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

        private void Basket_Is_Not_Empty()
        {
            Assert.That(_subject.BasketItems, Is.Not.Empty);
        }
    }

    public enum HarryPotterSeries
    {
        Philosophers_Stone = 1,
        Chamber_of_Secrets = 2,
        Prisoner_of_Azkaban = 3,
        Goblet_of_Fire = 4,
        Order_of_the_Phoenix = 5,
        Half_Blood_Prince = 6,
        Deathly_Hallows = 7
    }

    public class BookSet
    {
        public List<Book> Books { get; }

        private BookSet()
        {
            Books = new List<Book>();
        }
        
        public static BookSet Create()
        {
            return new BookSet();
        }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }
    }
    
    public class Book
    {
        public HarryPotterSeries Series { get; }

        public Book(HarryPotterSeries series)
        {
            Series = series;
        }
    }

    public class Basket
    {
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
            var bookSet = BookSet.Create();
            bookSet.AddBook(book);
            
            BasketItems.Add(bookSet);
        }
        
        public List<BookSet> BasketItems { get; }

        public void AddBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }
    }
}