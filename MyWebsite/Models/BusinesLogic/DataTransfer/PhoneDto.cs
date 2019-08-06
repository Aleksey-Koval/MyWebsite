namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

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
    }
}