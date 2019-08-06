using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Infrastructure;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {

        IShoppingCartServices shoppingCartServices;

        public ShoppingCartController(IShoppingCartServices services)
        {
            shoppingCartServices = services;
        }

        [HttpPost]
        public ActionResult GetAllProducts(string userId)
        {
            try
            {
                IEnumerable<ProductDto> productsDto = shoppingCartServices.GetAllProducts(userId);

                var products = MappingProductDtoToProductViewModel(productsDto);
                return View(products);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddProductToShoppingCart(int? productId, string userId)
        {
            try
            {
                shoppingCartServices.AddProductToShoppingCart(productId, userId);
                IEnumerable<ProductDto> productsDto = shoppingCartServices.GetAllProducts(userId);

                var products = MappingProductDtoToProductViewModel(productsDto);
                return View(products);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult RemoveProductInShoppigCart(int? productId, string userId)
        {
            try
            {
                shoppingCartServices.RemoveProductInShoppingCart(productId, userId);
                IEnumerable<ProductDto> productsDto = shoppingCartServices.GetAllProducts(userId);

                var products = MappingProductDtoToProductViewModel(productsDto);
                return View("GetAllProducts", products);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        private List<ProductViewModel> MappingProductDtoToProductViewModel(IEnumerable<ProductDto> productsDto)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductViewModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDto>, List<ProductViewModel>>(productsDto);
            return products;
        }

        protected override void Dispose(bool disposing)
        {
            shoppingCartServices.Dispose();
            base.Dispose(disposing);
        }
    }
}