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
            throw new System.NotImplementedException();
        }

        public double Rate { get; }
    }
}