using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string PublishingHouse { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int YearOfPublishing { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Annotation { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }
    }
}