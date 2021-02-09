using PotterKata.Enums;

namespace PotterKata.Models
{
    public class Book
    {
        private const double DefaultBookPrice = 8;
        
        public Book(Volumes volume, double price = DefaultBookPrice)
        {
            this.Volume = volume;
            this.Price = price;
        }

        public override string ToString()
        {
            return this.Volume.ToString();
        }

        public Volumes Volume { get; }

        public double Price { get; }
    }
}