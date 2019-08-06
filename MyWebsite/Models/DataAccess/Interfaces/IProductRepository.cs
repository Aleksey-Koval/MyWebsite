using MyWebsite.Models.DataAccess.Entities.Products;

namespace MyWebsite.Models.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Product Get(int? id);
    }
}
