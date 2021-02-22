using System.Collections;
using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void When_Number_Is_Divisible_By_Three_Then_Fizz()
        {
            var result = Kata.Execute(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void When_Number_Is_Divisible_By_Five_Then_Buzz()
        {
            var result = Kata.Execute(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [TestCase(15)]
        [TestCase(30)]
        public void When_Number_Is_Divisible_By_Three_And_Five_Then_FizzBuzz(int value)
        {
            var result = Kata.Execute(value);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
    }

    public class Kata
    {
        public static string Execute(int number)
        {
            var output = string.Empty;
            output += DivisibleByThree(number);
            output += DivisibleByFive(number);

            return output;
        }

        private static string DivisibleByThree(int number)
        {
            return number % 3 == 0 ? "Fizz" : string.Empty;
        }
        
        private static string DivisibleByFive(int number)
        {
            return number % 5 == 0 ? "Buzz" : string.Empty;
        }
    }
}