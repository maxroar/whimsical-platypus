namespace BeerBuddy
{
    public class LocationBeer : BaseEntity
    {
        public double price { get; set; }
        public string size { get; set; }
        public int beerId { get; set; }
        public int locationId { get; set; }
    }
}