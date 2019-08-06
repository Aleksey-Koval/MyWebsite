namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class TvDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        public string Company { get; set; }
        public int ScreenDiagonal { get; set; }
        public string ScreenResolution { get; set; }
        public bool SmartTv { get; set; }
        public bool WiFi { get; set; }
        public int Contrast { get; set; }
        public int ResponseTime { get; set; }
        public string Description { get; set; }
    }
}