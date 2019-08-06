using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.Entities;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IOrderStatusService
    {
        OrderStatus MakeOrderStatus(string orderStatusName);
        OrderStatus MakeOrderStatus();
        List<OrderStatusDto> GetOrderStatuses(int orderId);
        void Dispose();
    }
}
