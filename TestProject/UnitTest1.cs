using System.Collections.Generic;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class GiftAidCalculatorTests
    {
        [TestFixture]
        public class Given_A_Donation
        {
            private decimal result;

            [SetUp]
            public void When_The_Gift_Aid_Is_Calculated()
            {
                const decimal donationAmount = 100M;
                var subject = new GiftAidCalculator();

                this.result = subject.Calculate(donationAmount);
            }

            [Test]
            public void Then_The_Correct_Amount_Is_Returned()
            {
                Assert.That(this.result, Is.EqualTo(0.20));
            }
        }

        public class Given
        {

        }
    }

    public class MinimumDonationAmount
    {
        public decimal Value => 2M;

        public override string ToString()
        {
            return Value.ToString("F");
        }
    }

    public class MaximumDonationAmount
    {
        public decimal Value => 100000M;

        public override string ToString()
        {
            return Value.ToString("F");
        }
    }

    public class TaxRate
    {
        public decimal Value => (decimal) 0.2;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class GiftAidCalculator
    {
        public decimal Calculate(decimal donationAmount)
        {
            var taxRate = new TaxRate().Value;
            return decimal.Round(donationAmount * (taxRate / (100 - taxRate)), 2);
        }
    }

    public class GiftAidController
    {
        public GiftAidController() // dependency
        {
            
        }

        public GiftAidResponse Get(decimal amount)
        {
            var giftAidCalculator = new GiftAidCalculator();
            return null;
        }
    }

    public class GiftAidValidator
    {
        public List<Error> Validate(decimal donationAmount)
        {
            var minimumDonationAmount = new MinimumDonationAmount();
            var maximumDonationAmount = new MaximumDonationAmount();
            var errors = new List<Error>();

            if (donationAmount < minimumDonationAmount.Value)
            {
                errors.Add(new Error("InvalidDonationAmount", $"Donation amount must be greater than {minimumDonationAmount}"));
            }

            if (donationAmount > maximumDonationAmount.Value)
            {
                errors.Add(new Error("InvalidDonationAmount", $"Donation amount must be less than {maximumDonationAmount}"));
            }

            return errors;
        }
    }

    public class Error
    {
        public Error(string errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        public string ErrorCode { get; set; }

        public string Message { get; set; }
    }


    public class GiftAidResponse
    {
        public decimal DonationAmount { get; set; }

        public decimal GiftAidAmount { get; set; }
    }
}