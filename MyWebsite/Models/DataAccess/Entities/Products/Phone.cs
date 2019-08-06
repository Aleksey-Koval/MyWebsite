namespace MyWebsite.Models.DataAccess.Entities.Products
{
    public class Phone : Product
    {
        public string Company { get; set; }
        public string ScreenDiagonal { get; set; }
        public int Ram { get; set; }
        public int Memory { get; set; }
        public string CpuName { get; set; }
        public int CpuNumberOfCores { get; set; }
        public string CpuFrequncy { get; set; }
        public string OperatingSystem { get; set; }
        public int Camera { get; set; }
        public int FrontCamera { get; set; }
        public int BatteryCapacity { get; set; }
        public string Description { get; set; }

        public Phone() : base()
        {
        }
    }
}