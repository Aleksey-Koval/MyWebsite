using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models.ViewModel
{
    public class HeadphonesViewModel
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
        public string Type { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string TypeOfConnection { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Impedance { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string FrequencyRange { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public bool Microphone { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Description { get; set; }
    }
}