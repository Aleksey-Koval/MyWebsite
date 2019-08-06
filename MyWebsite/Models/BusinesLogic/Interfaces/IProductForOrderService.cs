using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.DataAccess.Entities;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IProductForOrderService
    {
        List<ProductForOrder> CreateProductsForOrder(List<ProductForOrderDto> productsForOrderDto);
        void Dispose();
    }
}
