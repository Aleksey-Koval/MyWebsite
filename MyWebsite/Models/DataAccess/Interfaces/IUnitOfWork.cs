using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.DataAccess.Interfaces;
using MyWebsite.Models.Entities;
using System;

namespace MyWebsite.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository Products { get; }
        IRepository<Book> Books { get; }
        IRepository<Phone> Phones { get; }
        IRepository<Headphones> Headphones { get; }
        IRepository<Tv> TvSets { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderStatus> OrderStatuses { get; }
        IRepository<ProductForOrder> ProductsForOrder { get; }
        IShoppingCartsRepository ShoppingCarts { get; }

        void Save();
    }
}
