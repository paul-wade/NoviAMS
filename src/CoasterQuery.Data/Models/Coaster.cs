namespace CoasterQuery.Data.Models
{
    public class Park
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDefunct { get; set; }
        public string Notes { get; set; }
        public int ParkID { get; set; }
        public string State { get; set; }
        public string Website { get; set; }
        public string Zip { get; set; }
    }
}