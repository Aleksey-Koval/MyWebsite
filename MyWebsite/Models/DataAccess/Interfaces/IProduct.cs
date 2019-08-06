using MyWebsite.Models.DataAccess.Entities;
using System.Collections.Generic;

namespace MyWebsite.Models.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }

        ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
