using NUnit.Framework;
using PotterKata.Models;

namespace PotterKata
{
    [TestFixture]
    public class DiscountTests
    {
        [Test]
        public void Given_Two_Books_When_Determining_Discount_Rate_Then_Five_Percent_Discount_Is_Returned()
        {
            const int numberOfBooks = 2;
            var discount = Discount.Create(numberOfBooks);
            
            Assert.That(discount.Rate, Is.EqualTo(0.95));
        }
        
        [Test]
        public void Given_Three_Books_When_Determining_Discount_Rate_Then_Ten_Percent_Discount_Is_Returned()
        {
            const int numberOfBooks = 3;
            var discount = Discount.Create(numberOfBooks);
            
            Assert.That(discount.Rate, Is.EqualTo(0.90));
        }
    }
}