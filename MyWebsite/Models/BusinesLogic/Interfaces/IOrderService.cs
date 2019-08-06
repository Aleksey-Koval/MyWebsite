using MyWebsite.Models.BusinesLogic.DataTransfer;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDto orderDto);
        List<OrderDto> GetOrders(string userId);
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderDetails(int orderId);
        void AddNewOrderStatus(int orderId, string orderderStatusName);
        void RemoveProductInOrder(int orderId, int productId);
        void Update(OrderDto orderDto);

        OrderDto GetLastOrder(string userId);
        List<OrderStatusDto> GetOrderStatusesInTheOrder(int orderId);
        List<OrderDto> LookForOrders(string orderStatus);

        void Dispose();
    }
}