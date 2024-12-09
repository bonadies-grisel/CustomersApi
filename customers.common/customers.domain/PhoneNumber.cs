namespace customers.domain
{
    public class PhoneNumber : Generic32
    {
        public PhoneNumber() { }
        public string Phone { get; set; }
        public PhoneCode PhoneCode { get; set; }
    }
}
