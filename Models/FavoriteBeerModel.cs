namespace BeerBuddy
{
    public class FavoriteBeer : BaseEntity
    {
        int userId { get; set; }
        int beerId { get; set; }
    }
}