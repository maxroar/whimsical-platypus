namespace BeerBuddy
{
    public class FavoriteLocation : BaseEntity
    {
        public int userId { get; set; }
        public int locationId { get; set; }
    }
}