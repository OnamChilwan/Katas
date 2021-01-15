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
    }

    public class Kata
    {
        public string Execute(int number)
        {
            return "Fizz";
        }
    }

}