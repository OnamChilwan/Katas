using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void When_Number_Is_Divisible_By_Three_Then_Fizz()
        {
            var subject = new Kata();
            var result = subject.Execute(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void When_Number_Is_Divisible_By_Five_Then_Buzz()
        {
            var subject = new Kata();
            var result = subject.Execute(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }
        
    }

    public class Kata
    {
        public string Execute(int number)
        {
            return "Fizz";
        }
    }
}