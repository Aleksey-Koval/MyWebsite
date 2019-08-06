using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWebsite.Models.DataAccess.Repositories
{
    public class ProductForOrderRepository : IRepository<ProductForOrder>
    {
        private ApplicationDbContext db;

        public ProductForOrderRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProductForOrder> GetAll()
        {
            return db.ProductsForOrder;
        }

        public ProductForOrder Get(int id)
        {
            return db.ProductsForOrder.Find(id);
        }

        public void Create(ProductForOrder ProductForOrder)
        {
            db.ProductsForOrder.Add(ProductForOrder);
        }

        public void Update(ProductForOrder ProductForOrder)
        {
            db.Entry(ProductForOrder).State = EntityState.Modified;
        }

        public IEnumerable<ProductForOrder> Find(Func<ProductForOrder, bool> predicate)
        {
            return db.ProductsForOrder.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ProductForOrder ProductForOrder = db.ProductsForOrder.Find(id);
            if (ProductForOrder != null)
                db.ProductsForOrder.Remove(ProductForOrder);
        }

    }
}