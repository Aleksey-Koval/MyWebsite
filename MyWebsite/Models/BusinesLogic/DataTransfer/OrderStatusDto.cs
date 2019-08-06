using System;

namespace MyWebsite.Models.BusinesLogic.DataTransfer
{
    public class OrderStatusDto
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public DateTime Date { get; set; }
    }
}