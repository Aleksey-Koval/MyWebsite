namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublishingHouse { get; set; }
        public int YearOfPublishing { get; set; }
        public string Annotation { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}