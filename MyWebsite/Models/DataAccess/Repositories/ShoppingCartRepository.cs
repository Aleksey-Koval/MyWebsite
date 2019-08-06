using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWebsite.Models.DataAccess.Repositories
{
    public class ShoppingCartRepository : IShoppingCartsRepository
    {
        private ApplicationDbContext db;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public ShoppingCart Get(string id)
        {
            return db.ShoppingCarts.Find(id);
        }

        public void Create(ShoppingCart ShoppingCart)
        {
            db.ShoppingCarts.Add(ShoppingCart);
        }

        public void Update(ShoppingCart ShoppingCart)
        {
            db.Entry(ShoppingCart).State = EntityState.Modified;
        }

        public IEnumerable<ShoppingCart> Find(Func<ShoppingCart, bool> predicate)
        {
            return db.ShoppingCarts.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            ShoppingCart ShoppingCart = db.ShoppingCarts.Find(id);
            if (ShoppingCart != null)
                db.ShoppingCarts.Remove(ShoppingCart);
        }
    }
}