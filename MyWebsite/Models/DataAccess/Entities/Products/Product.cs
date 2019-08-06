using MyWebsite.Models.Interfaces;
using System.Collections.Generic;


namespace MyWebsite.Models.DataAccess.Entities.Products
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public Product()
        {
            ShoppingCarts = new List<ShoppingCart>();
        }
    }
}