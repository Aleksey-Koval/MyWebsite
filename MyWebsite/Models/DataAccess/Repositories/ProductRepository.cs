using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.DataAccess.Interfaces;

namespace MyWebsite.Models.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public Product Get(int? id)
        {
            return db.Products.Find(id);
        }
    }
}