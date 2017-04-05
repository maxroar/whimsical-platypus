namespace BeerBuddy
{
    public class Brewery : BaseEntity
    {
        public string name { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public int yearFounded { get; set; }
    }
}