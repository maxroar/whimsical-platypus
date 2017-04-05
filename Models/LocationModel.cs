namespace BeerBuddy
{
    public class Location : BaseEntity
    {
        public string name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public string type { get; set; }
        public string happyHour { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string yelpId { get; set; }
    }
}