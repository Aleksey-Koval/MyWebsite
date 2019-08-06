using MyWebsite.Models.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int QuantityProducts { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }

        public DateTime Date { get; set; }
        public string Orderstatus { get; set; }

        public virtual List<ProductForOrder> ProductsForOrder { get; set; }
        public virtual List<OrderStatus> OrderStatuses { get; set; }

        public Order()
        {
            ProductsForOrder = new List<ProductForOrder>();
            OrderStatuses = new List<OrderStatus>();
        }
    }
}