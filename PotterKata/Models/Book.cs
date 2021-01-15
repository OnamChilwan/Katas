using PotterKata.Enums;

namespace PotterKata.Models
{
    public class Book
    {
        public HarryPotterSeries Series { get; }

        public Book(HarryPotterSeries series)
        {
            Series = series;
        }
    }
}