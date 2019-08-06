using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Infrastructure;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        IUnitOfWork Database { get; set; }

        public ShoppingCartServices(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<ProductDto> GetAllProducts(string userId)
        {
            ShoppingCart shoppingCart = LookForShoppingCart(userId);
            List<Product> products = shoppingCart.Products.ToList();

            var productsDto = MappingProductsForOrderToProductsForOrderDto(products);

            return productsDto;
        }
        public void AddProductToShoppingCart(int? productId, string userId)
        {
            Product product = LookForProduct(productId);
            ShoppingCart shoppingCart = LookForShoppingCart(userId);

            shoppingCart.Products.Add(product);
            Database.ShoppingCarts.Update(shoppingCart);
            Database.Save();
        }
        public void RemoveProductInShoppingCart(int? productId, string userId)
        {
            Product product = LookForProduct(productId);
            ShoppingCart shoppingCart = LookForShoppingCart(userId);

            shoppingCart.Products.Remove(product);
            Database.ShoppingCarts.Update(shoppingCart);
            Database.Save();
        }
        public void ClearShoppingCart(string userId)
        {
            ShoppingCart shoppingCart = LookForShoppingCart(userId);
            shoppingCart.Products.Clear();
            Database.ShoppingCarts.Update(shoppingCart);
            Database.Save();
        }
        private ShoppingCart LookForShoppingCart(string userId)
        {
            if (userId == null)
                throw new ValidationException("Пользователь не установлен", "");
            ShoppingCart shoppingCart = Database.ShoppingCarts.Get(userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    Id = userId
                };

                Database.ShoppingCarts.Create(shoppingCart);
                Database.Save();
            }
            return shoppingCart;
        }
        private Product LookForProduct(int? productId)
        {
            if (productId == null)
                throw new ValidationException("Не установлено id продукта", "");
            Product product = Database.Products.Get(productId);
            if (product == null)
                throw new ValidationException("Продукт не найден", "");
            return product;
        }

        private List<ProductDto> MappingProductsForOrderToProductsForOrderDto(List<Product> products)
        {
            var productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(MappingProductToProductDto(product));
            }

            return productsDto;
        }

        private ProductDto MappingProductToProductDto(Product product)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDto>()).CreateMapper();
            var productDto = mapper.Map<Product, ProductDto>(product);

            productDto.ProductType = product.GetType().BaseType.Name.ToString();
            return productDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}