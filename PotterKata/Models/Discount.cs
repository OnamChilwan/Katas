namespace PotterKata.Models
{
    public class Discount
    {
        private const double NoDiscount = 1;
        private const double FivePercentDiscount = 0.95;
        private const double TenPercentDiscount = 0.90;
        private const double TwentyPercentDiscount = 0.80;
        private const double TwentyFivePercentDiscount = 0.75;
        
        private Discount(double rate)
        {
            this.Rate = rate;
        }
        
        public static Discount Create(int numberOfBooks)
        {
            return numberOfBooks switch
            {
                2 => new Discount(FivePercentDiscount),
                3 => new Discount(TenPercentDiscount),
                4 => new Discount(TwentyPercentDiscount),
                5 => new Discount(TwentyFivePercentDiscount),
                _ => new Discount(NoDiscount)
            };
        }

        public double Rate { get; }
    }
}