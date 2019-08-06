using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Entities;

namespace MyWebsite.Models.DataAccess.Entities
{
    public class ProductForOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Sum { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public byte[] Image { get; set; }

    }
}