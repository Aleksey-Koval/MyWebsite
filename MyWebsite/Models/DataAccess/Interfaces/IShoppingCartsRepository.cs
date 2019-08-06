using MyWebsite.Models.DataAccess.Entities;

namespace MyWebsite.Models.DataAccess.Interfaces
{
    public interface IShoppingCartsRepository
    {
        ShoppingCart Get(string id);
        void Create(ShoppingCart item);
        void Update(ShoppingCart item);
        void Delete(string id);
    }
}