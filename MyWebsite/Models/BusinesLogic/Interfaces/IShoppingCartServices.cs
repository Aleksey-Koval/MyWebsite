using MyWebsite.Models.BusinesLogic.DataTransfer;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IShoppingCartServices
    {
        void AddProductToShoppingCart(int? productID, string userId);
        void RemoveProductInShoppingCart(int? productId, string userId);
        void ClearShoppingCart(string userId);
        IEnumerable<ProductDto> GetAllProducts(string userId);
        void Dispose();
    }
}