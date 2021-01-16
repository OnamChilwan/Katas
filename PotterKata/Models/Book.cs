using PotterKata.Enums;

namespace PotterKata.Models
{
    public class Book
    {
        public Volumes Volume { get; }

        public Book(Volumes volume)
        {
            Volume = volume;
        }

        public override string ToString()
        {
            return this.Volume.ToString();
        }
    }
}