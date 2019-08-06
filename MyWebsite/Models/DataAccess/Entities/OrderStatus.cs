using System;

namespace MyWebsite.Models.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public DateTime Date { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public OrderStatus()
        {
            Date = DateTime.Now;
            StatusName = "Новый заказ";
        }
        public OrderStatus(string statusName)
        {
            Date = DateTime.Now;
            StatusName = statusName;
        }

    }
}