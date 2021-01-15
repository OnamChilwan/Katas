namespace PotterKata.Models
{
    public class Discount
    {
        private Discount(double rate)
        {
            this.Rate = rate;
        }
        
        public static Discount Create(int numberOfBooks)
        {
            return new Discount(0.95);
        }

        public double Rate { get; }
    }
}