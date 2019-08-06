using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models.ViewModel
{
    public class PhoneViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string ScreenDiagonal { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Ram { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Memory { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string CpuName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int CpuNumberOfCores { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string CpuFrequncy { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Camera { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int FrontCamera { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int BatteryCapacity { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Description { get; set; }

    }
}