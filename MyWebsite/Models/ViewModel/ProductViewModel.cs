namespace MyWebsite.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Sum { get; set; }
        public byte[] Image { get; set; }
        public ProductViewModel()
        {
            Quantity = 1;
        }
    }
}