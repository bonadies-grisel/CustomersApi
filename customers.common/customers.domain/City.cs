namespace customers.domain
{
    public class City : Generic32
    {
        public City() { }
        public string? CityName { get; set; }
        public Country? Country { get; set; }


    }
}
