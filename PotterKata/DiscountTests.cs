using NUnit.Framework;
using PotterKata.Models;

namespace PotterKata
{
    [TestFixture]
    public class DiscountTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 0.95)]
        [TestCase(3, 0.90)]
        [TestCase(4, 0.80)]
        [TestCase(5, 0.75)]
        public void Given_X_Books_When_Determining_Discount_Rate_Then_The_Correct_Discount_Is_Returned(int numberOfBooks, double expectedDiscount)
        {
            var discount = Discount.Create(numberOfBooks);
            
            Assert.That(discount.Rate, Is.EqualTo(expectedDiscount));
        }
    }
}