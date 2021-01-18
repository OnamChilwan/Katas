﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Models
{
    public class Basket
    {
        public List<BookSet> BasketItems { get; }
        
        public double Total => BasketItems.Sum(x => x.Price);

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
            BookSet cheapestBookSet = null;
            var cheapestPriceSoFar = double.MaxValue; // set it to highest possible value
            
            foreach (var bookSet in BasketItems)
            {
                if (bookSet.Contains(book))
                {
                    continue;
                }

                if (bookSet.Price > cheapestPriceSoFar)
                {
                    continue;
                }
                
                cheapestBookSet = bookSet;
                cheapestPriceSoFar = bookSet.Price;
            }

            if (cheapestBookSet == null)
            {
                cheapestBookSet = BookSet.Create();
                BasketItems.Add(cheapestBookSet);
            }
            
            cheapestBookSet.AddBook(book);
        }

        public void AddBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }
    }
}