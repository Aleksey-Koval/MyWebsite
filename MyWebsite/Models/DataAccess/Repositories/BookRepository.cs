using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace MyWebsite.Models.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private ApplicationDbContext db;

        public BookRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }
}