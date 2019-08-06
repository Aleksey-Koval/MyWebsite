namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}