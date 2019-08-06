using System;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int QuantityProducts { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string Orderstatus { get; set; }
        public DateTime Date { get; set; }
        public virtual List<ProductForOrderDto> ProductsForOrderDto { get; set; }

        public OrderDto()
        {
            ProductsForOrderDto = new List<ProductForOrderDto>();
        }
    }
}