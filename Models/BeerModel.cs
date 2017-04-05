namespace BeerBuddy
{
    public class Beer : BaseEntity
    {
        public string name { get; set; }
        public string type { get; set; }
        public double abv { get; set; }
        public int breweryId { get; set; }
        public string exclusivity { get; set; }
        public string availability { get; set; }
        public string seasonal { get; set; }
    }
}