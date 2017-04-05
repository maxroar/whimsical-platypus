namespace BeerBuddy
{
    public class BeerRating : BaseEntity
    {
        public int rating { get; set; }
        public string review { get; set; }
        public int userId { get; set; }
        public int beerId { get; set; }
    }
}