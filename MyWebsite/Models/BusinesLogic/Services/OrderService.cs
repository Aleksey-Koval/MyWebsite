using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder(OrderDto orderDto)
        {
            ShoppingCartServices shoppingCartServices = new ShoppingCartServices(Database);

            OrderStatusService orderderStatusService = new OrderStatusService(Database);
            var orderStatus = orderderStatusService.MakeOrderStatus();

            ProductForOrderService productForOrderService = new ProductForOrderService(Database);
            var productForOrder = productForOrderService.CreateProductsForOrder(orderDto.ProductsForOrderDto);

            int quantityProducts = 0;
            foreach (var product in productForOrder)
            {
                quantityProducts += product.Quantity;
            }

            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                QuantityProducts = quantityProducts,
                Sum = orderDto.Sum,
                ApplicationUserId = orderDto.UserId,
                PhoneNumber = orderDto.PhoneNumber,
                Orderstatus = orderStatus.StatusName,
                PaymentMethod = orderDto.PaymentMethod
            };

            order.OrderStatuses.Add(orderStatus);
            order.ProductsForOrder.AddRange(productForOrder);

            Database.Orders.Create(order);
            shoppingCartServices.ClearShoppingCart(orderDto.UserId);
            Database.Save();
        }
        public List<OrderDto> GetOrders(string userId)
        {
            var orders = Database.Orders.Find(m => m.ApplicationUserId == userId).ToList();

            var ordersDto = MappingOrdersToOrdersDto(orders);
            return ordersDto;
        }
        public List<OrderDto> GetAllOrders()
        {
            var orders = Database.Orders.GetAll().ToList();

            var ordersDto = MappingOrdersToOrdersDto(orders);
            return ordersDto;
        }

        public List<OrderDto> LookForOrders(string orderStatus)
        {
            var orders = Database.Orders.Find(m => m.Orderstatus == orderStatus);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>()
                .ForMember(d => d.UserId, m => m.MapFrom(s => s.ApplicationUserId)))
                .CreateMapper();
            var ordersDto = mapper.Map<IEnumerable<Order>, List<OrderDto>>(orders);
            return ordersDto;
        }

        public void AddNewOrderStatus(int orderId, string orderderStatusName)
        {
            var order = Database.Orders.Get(orderId);
            OrderStatusService orderderStatusService = new OrderStatusService(Database);
            var newOrderStatus = orderderStatusService.MakeOrderStatus(orderderStatusName);
            order.OrderStatuses.Add(newOrderStatus);
            order.Orderstatus = newOrderStatus.StatusName;
            Database.Orders.Update(order);
            Database.Save();
        }

        public void Update(OrderDto orderDto)
        {
            var order = Database.Orders.Get(orderDto.Id);
            order.Sum = 0;
            order.QuantityProducts = 0;
            foreach (var product in orderDto.ProductsForOrderDto)
            {
                var productForOrder = order.ProductsForOrder.Find(m => m.Id == product.Id);
                if (product.Quantity != productForOrder.Quantity)
                {
                    productForOrder.Quantity = product.Quantity;
                    productForOrder.Sum = product.Quantity * productForOrder.Price;
                    Database.ProductsForOrder.Update(productForOrder);
                }
                order.Sum += productForOrder.Sum;
                order.QuantityProducts += productForOrder.Quantity;
            }

            OrderStatusService orderderStatusService = new OrderStatusService(Database);
            var newOrderStatus = orderderStatusService.MakeOrderStatus(orderDto.Orderstatus);

            order.OrderStatuses.Add(newOrderStatus);
            order.Address = orderDto.Address;
            order.PaymentMethod = orderDto.PaymentMethod;
            order.Orderstatus = newOrderStatus.StatusName;
            Database.Orders.Update(order);
            Database.Save();
        }

        public void RemoveProductInOrder(int orderId, int productId)
        {
            var order = Database.Orders.Get(orderId);
            var product = order.ProductsForOrder.Find(m => m.Id == productId);
            order.ProductsForOrder.Remove(product);
            Database.Orders.Update(order);
            Database.Save();
        }


        public OrderDto GetOrderDetails(int orderId)
        {
            var order = Database.Orders.Get(orderId);

            var orderDto = MappingOrderToOrderDto(order);

            return orderDto;
        }

        public List<OrderStatusDto> GetOrderStatusesInTheOrder(int orderId)
        {
            var order = Database.Orders.Get(orderId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderStatus, OrderStatusDto>()).CreateMapper();
            var orderStatusesDto = mapper.Map<List<OrderStatus>, List<OrderStatusDto>>(order.OrderStatuses);
            return orderStatusesDto;
        }
        public OrderDto GetLastOrder(string userId)
        {
            var order = Database.Orders.Find(m => m.ApplicationUserId == userId).Last();
            var orderDto = MappingOrderToOrderDto(order);

            return orderDto;
        }
        private List<OrderDto> MappingOrdersToOrdersDto(List<Order> orders)
        {
            var ordersDto = new List<OrderDto>();
            foreach (var order in orders)
            {
                ordersDto.Add(MappingOrderToOrderDto(order));
            }

            return ordersDto;
        }

        private OrderDto MappingOrderToOrderDto(Order order)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>()
                .ForMember(d => d.UserId, m => m.MapFrom(s => s.ApplicationUserId)))
                .CreateMapper();
            var orderDto = mapper.Map<Order, OrderDto>(order);
            var productsForOrderDto = MappingProductsForOrderToProductsForOrderDto(order);

            orderDto.ProductsForOrderDto.AddRange(productsForOrderDto);

            return orderDto;
        }

        private List<ProductForOrderDto> MappingProductsForOrderToProductsForOrderDto(Order order)
        {
            var productsForOrderDto = new List<ProductForOrderDto>();
            foreach (var productForOrder in order.ProductsForOrder)
            {
                productsForOrderDto.Add(MappingProductForOrderToProductForOrderDto(productForOrder));
            }
            return productsForOrderDto;
        }

        private ProductForOrderDto MappingProductForOrderToProductForOrderDto(ProductForOrder productForOrder)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductForOrder, ProductForOrderDto>()).CreateMapper();
            var productForOrderDto = mapper.Map<ProductForOrder, ProductForOrderDto>(productForOrder);

            return productForOrderDto;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}