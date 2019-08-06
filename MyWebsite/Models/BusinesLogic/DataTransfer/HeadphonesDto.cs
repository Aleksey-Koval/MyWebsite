namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class HeadphonesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        public string Company { get; set; }
        public string Type { get; set; }
        public string TypeOfConnection { get; set; }
        public int Impedance { get; set; }
        public string FrequencyRange { get; set; }
        public bool Microphone { get; set; }
        public string Description { get; set; }
    }
}