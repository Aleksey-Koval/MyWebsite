using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWebsite.Models.DataAccess.Repositories
{
    public class HeadphonesRepository : IRepository<Headphones>
    {
        private ApplicationDbContext db;

        public HeadphonesRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Headphones> GetAll()
        {
            return db.Headphones;
        }

        public Headphones Get(int id)
        {
            return db.Headphones.Find(id);
        }

        public void Create(Headphones headphones)
        {
            db.Headphones.Add(headphones);
        }

        public void Update(Headphones headphones)
        {
            db.Entry(headphones).State = EntityState.Modified;
        }

        public IEnumerable<Headphones> Find(Func<Headphones, bool> predicate)
        {
            return db.Headphones.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Headphones headphones = db.Headphones.Find(id);
            if (headphones != null)
                db.Headphones.Remove(headphones);
        }
    }
}