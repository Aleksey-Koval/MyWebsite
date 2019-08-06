using MyWebsite.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class ShoppingCartDto
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int ProductId { get; set; }
        public IProduct Product { get; set; }

        public ICollection<ProductDto> Products { get; set; }

        public ShoppingCartDto()
        {
            Products = new List<ProductDto>();
        }
    }
}