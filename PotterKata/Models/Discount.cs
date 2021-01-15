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
            double discount = 0;
            
            switch (numberOfBooks)
            {
                case 2:
                    discount = 0.95;
                    break;
                case 3:
                    discount = 0.90;
                    break;
            }
            
            return new Discount(discount);
        }

        public double Rate { get; }
    }
}