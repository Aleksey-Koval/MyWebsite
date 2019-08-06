using MyWebsite.Models.Entities;
using MyWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWebsite.Models.Repositories
{
    public class OrderStatusRepository : IRepository<OrderStatus>
    {
        private ApplicationDbContext db;

        public OrderStatusRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return db.OrderStatuses;
        }

        public OrderStatus Get(int id)
        {
            return db.OrderStatuses.Find(id);
        }

        public void Create(OrderStatus OrderStatus)
        {
            db.OrderStatuses.Add(OrderStatus);
        }

        public void Update(OrderStatus OrderStatus)
        {
            db.Entry(OrderStatus).State = EntityState.Modified;
        }

        public IEnumerable<OrderStatus> Find(Func<OrderStatus, bool> predicate)
        {
            return db.OrderStatuses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            OrderStatus OrderStatus = db.OrderStatuses.Find(id);
            if (OrderStatus != null)
                db.OrderStatuses.Remove(OrderStatus);
        }
    }
}