using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWebsite.Models.DataAccess.Repositories
{
    public class TvRepository : IRepository<Tv>
    {
        private ApplicationDbContext db;

        public TvRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tv> GetAll()
        {
            return db.TvSets;
        }

        public Tv Get(int id)
        {
            return db.TvSets.Find(id);
        }

        public void Create(Tv tv)
        {
            db.TvSets.Add(tv);
        }

        public void Update(Tv tv)
        {
            db.Entry(tv).State = EntityState.Modified;
        }

        public IEnumerable<Tv> Find(Func<Tv, bool> predicate)
        {
            return db.TvSets.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Tv tv = db.TvSets.Find(id);
            if (tv != null)
                db.TvSets.Remove(tv);
        }
    }
}