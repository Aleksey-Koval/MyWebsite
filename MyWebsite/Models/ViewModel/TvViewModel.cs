using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models.ViewModel
{
    public class TvViewModel
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
        public int ScreenDiagonal { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string ScreenResolution { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public bool SmartTv { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public bool WiFi { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Contrast { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int ResponseTime { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Description { get; set; }
    }
}