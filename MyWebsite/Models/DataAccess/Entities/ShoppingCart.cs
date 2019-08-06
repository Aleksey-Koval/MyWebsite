using MyWebsite.Models.DataAccess.Entities.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models.DataAccess.Entities
{
    public class ShoppingCart
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public ShoppingCart()
        {
            Products = new List<Product>();
        }
    }
}