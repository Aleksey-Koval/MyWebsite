using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        IUnitOfWork Database { get; set; }

        public OrderStatusService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public OrderStatus MakeOrderStatus(string orderStatusName)
        {
            OrderStatus orderStatus = new OrderStatus(orderStatusName);
            Database.OrderStatuses.Create(orderStatus);
            Database.Save();
            return orderStatus;

        }
        public OrderStatus MakeOrderStatus()
        {
            OrderStatus orderStatus = new OrderStatus();
            Database.OrderStatuses.Create(orderStatus);
            Database.Save();
            return orderStatus;
        }

        public List<OrderStatusDto> GetOrderStatuses(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}