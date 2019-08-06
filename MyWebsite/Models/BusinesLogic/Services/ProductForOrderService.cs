using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.Interfaces;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class ProductForOrderService : IProductForOrderService
    {
        IUnitOfWork Database { get; set; }

        public ProductForOrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<ProductForOrder> CreateProductsForOrder(List<ProductForOrderDto> productsForOrderDto)
        {

            List<ProductForOrder> productsForOrder = new List<ProductForOrder>();

            foreach (ProductForOrderDto productForOrderDto in productsForOrderDto)
            {
                var product = Database.Products.Get(productForOrderDto.ProductId);

                ProductForOrder productForOrder = new ProductForOrder();
                productForOrder.Image = product.Image;
                productForOrder.Name = product.Name;
                productForOrder.Price = product.Price;
                productForOrder.ProductId = product.Id;
                productForOrder.Quantity = productForOrderDto.Quantity;
                productForOrder.Sum = productForOrder.Price * productForOrder.Quantity;
                productForOrder.ProductType = product.GetType().BaseType.Name.ToString();
                Database.ProductsForOrder.Create(productForOrder);
                productsForOrder.Add(productForOrder);
            }

            Database.Save();

            return productsForOrder;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}