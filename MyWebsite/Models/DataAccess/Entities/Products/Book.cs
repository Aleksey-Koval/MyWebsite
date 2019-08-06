namespace MyWebsite.Models.DataAccess.Entities.Products
{
    public class Book : Product
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublishingHouse { get; set; }
        public int YearOfPublishing { get; set; }
        public string Annotation { get; set; }

        public Book() : base()
        {

        }
    }
}