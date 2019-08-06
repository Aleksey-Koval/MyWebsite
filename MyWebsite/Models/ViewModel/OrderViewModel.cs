using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string Orderstatus { get; set; }

        [DisplayName("Количество товара")]
        public int QuantityProducts { get; set; }
        public DateTime Date { get; set; }
        public virtual List<ProductForOrderViewModel> ProductsForOrderViewModel { get; set; }

        public OrderViewModel()
        {
            ProductsForOrderViewModel = new List<ProductForOrderViewModel>();
        }
    }
}