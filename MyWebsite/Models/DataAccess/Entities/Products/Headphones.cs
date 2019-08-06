namespace MyWebsite.Models.DataAccess.Entities.Products
{
    public class Headphones : Product
    {
        public string Company { get; set; }
        public string Type { get; set; }
        public string TypeOfConnection { get; set; }
        public int Impedance { get; set; }
        public string FrequencyRange { get; set; }
        public bool Microphone { get; set; }
        public string Description { get; set; }
        public Headphones() : base()
        {
        }
    }
}