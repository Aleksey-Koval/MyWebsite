using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.DataAccess.Interfaces;
using MyWebsite.Models.DataAccess.Repositories;
using MyWebsite.Models.Entities;

using MyWebsite.Models.Interfaces;

using System;

namespace MyWebsite.Models.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;

        private ProductRepository productRepository;
        private PhoneRepository phoneRepository;
        private BookRepository bookRepository;
        private TvRepository tvRepository;
        private HeadphonesRepository headphonesRepository;

        private OrderRepository orderRepository;
        private OrderStatusRepository orderStatusRepository;
        private ShoppingCartRepository shoppingCartRepository;
        private ProductForOrderRepository productForOrderRepository;


        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationDbContext(connectionString);
        }
        public IProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public IRepository<Phone> Phones
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new PhoneRepository(db);
                return phoneRepository;
            }
        }
        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }
        public IRepository<Headphones> Headphones
        {
            get
            {
                if (headphonesRepository == null)
                    headphonesRepository = new HeadphonesRepository(db);
                return headphonesRepository;
            }
        }
        public IRepository<Tv> TvSets
        {
            get
            {
                if (tvRepository == null)
                    tvRepository = new TvRepository(db);
                return tvRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<ProductForOrder> ProductsForOrder
        {
            get
            {
                if (productForOrderRepository == null)
                    productForOrderRepository = new ProductForOrderRepository(db);
                return productForOrderRepository;
            }
        }

        public IRepository<OrderStatus> OrderStatuses
        {
            get
            {
                if (orderStatusRepository == null)
                    orderStatusRepository = new OrderStatusRepository(db);
                return orderStatusRepository;
            }
        }

        public IShoppingCartsRepository ShoppingCarts
        {
            get
            {
                if (shoppingCartRepository == null)
                    shoppingCartRepository = new ShoppingCartRepository(db);
                return shoppingCartRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}