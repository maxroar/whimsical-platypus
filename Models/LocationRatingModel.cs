namespace BeerBuddy
{
    public class LocationRating : BaseEntity
    {
        public int rating { get; set; }
        public string review { get; set; }
        public int userId { get; set; }
        public int locationId { get; set; }
    }
}