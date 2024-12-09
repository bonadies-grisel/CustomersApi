namespace customers.domain
{
    public class PhoneCode : Generic32
    {
        public PhoneCode() { }
        public string Code { get; set; }
        public Country Country { get; set; }
    }
}
