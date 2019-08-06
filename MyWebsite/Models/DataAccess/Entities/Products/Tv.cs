namespace MyWebsite.Models.DataAccess.Entities.Products
{
    public class Tv : Product
    {
        public string Company { get; set; }
        public int ScreenDiagonal { get; set; }
        public string ScreenResolution { get; set; }
        public bool SmartTv { get; set; }
        public bool WiFi { get; set; }
        public int Contrast { get; set; }
        public int ResponseTime { get; set; }
        public string Description { get; set; }

        public Tv() : base()
        {
        }
    }
}