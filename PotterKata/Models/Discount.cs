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
            switch (numberOfBooks)
            {
                case 2:
                    return new Discount(FivePercentDiscount);
                case 3:
                    return new Discount(TenPercentDiscount);
                case 4:
                    return new Discount(TwentyPercentDiscount);
                case 5:
                    return new Discount(TwentyFivePercentDiscount);
            }
            
            return new Discount(NoDiscount);
        }

        public double Rate { get; }
    }
}