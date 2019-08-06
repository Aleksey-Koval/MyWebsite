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
    public class OrderController : Controller
    {
        IOrderService orderService;
        public OrderController(IOrderService services)
        {
            orderService = services;
        }

        [HttpPost]
        public ActionResult MakeOrder(List<ProductViewModel> productViewModel)
        {
            try
            {

                var productsForOrderViewModel = MappingProductsViewModelToProductsForOrderViewModel(productViewModel);

                var orderViewModel = new OrderViewModel { };
                foreach (ProductForOrderViewModel product in productsForOrderViewModel)
                {
                    orderViewModel.Sum += product.Quantity * product.Price;
                    product.Sum = product.Quantity * product.Price;
                    orderViewModel.ProductsForOrderViewModel.Add(product);
                }
                return View(orderViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            try
            {
                OrderDto orderDto = MappingOrderViewModelToOrderDto(orderViewModel);
                orderService.MakeOrder(orderDto);

                var lastOrderDto = orderService.GetLastOrder(orderViewModel.UserId);
                var lastOrderViewModel = MappingOrderDtoToOrderViewModel(lastOrderDto);
                return View(lastOrderViewModel);
            }

            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult GetOrders(string userId)
        {
            try
            {
                var ordersDto = orderService.GetOrders(userId);
                var ordersViewModel = MappingOrdersDtoToOrdersViewModel(ordersDto);
                return View(ordersViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult GetAllOrders()
        {
            try
            {
                var ordersDto = orderService.GetAllOrders();
                var ordersViewModel = MappingOrdersDtoToOrdersViewModel(ordersDto);
                return View(ordersViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "manager")]
        public ActionResult LookForNewOrders()
        {
            try
            {
                string statusOrder = "Новый заказ";
                var ordersDto = orderService.LookForOrders(statusOrder);
                var ordersViewModel = MappingOrdersDtoToOrdersViewModel(ordersDto);
                return View(ordersViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "deliveryManager")]
        public ActionResult LookForDeliveryOrders()
        {
            try
            {
                string statusOrder = "В работе";
                var ordersDto = orderService.LookForOrders(statusOrder);
                var ordersViewModel = MappingOrdersDtoToOrdersViewModel(ordersDto);
                return View(ordersViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult GetNewOrderDetails(int orderId)
        {
            try
            {
                var orderDto = orderService.GetOrderDetails(orderId);
                var orderViewModel = MappingOrderDtoToOrderViewModel(orderDto);

                return View(orderViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "deliveryManager")]
        public ActionResult GetDeliveryOrdersDetails(int orderId)
        {
            try
            {
                var orderDto = orderService.GetOrderDetails(orderId);
                var orderViewModel = MappingOrderDtoToOrderViewModel(orderDto);

                return View(orderViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GetOrderDetails(int orderId)
        {
            try
            {
                var orderDto = orderService.GetOrderDetails(orderId);
                var orderViewModel = MappingOrderDtoToOrderViewModel(orderDto);

                return View(orderViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult DetailsOrderStauses(int orderId)
        {
            try
            {
                var orderStatusesDto = orderService.GetOrderStatusesInTheOrder(orderId);

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderStatusDto, OrderStatusViewModel>()).CreateMapper();
                var orderStatusViewModels = mapper.Map<List<OrderStatusDto>, List<OrderStatusViewModel>>(orderStatusesDto);

                return PartialView(orderStatusViewModels);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "manager, deliveryManager")]
        public ActionResult ChangeOrderStatus(int orderId, string orderStatus)
        {
            try
            {
                orderService.AddNewOrderStatus(orderId, orderStatus);

                var orderDto = orderService.GetOrderDetails(orderId);
                var orderViewModel = MappingOrderDtoToOrderViewModel(orderDto);

                return View("GetOrderDetails", orderViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UpdateNewOrder(OrderViewModel orderViewModel)
        {
            try
            {
                var orderDtoForUpdate = MappingOrderViewModelToOrderDto(orderViewModel);
                orderService.Update(orderDtoForUpdate);

                var orderDto = orderService.GetOrderDetails(orderViewModel.Id);
                var orderViewModel2 = MappingOrderDtoToOrderViewModel(orderDto);

                return View("GetOrderDetails", orderViewModel2);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult RemoveProduct(int orderId, int productId)
        {
            try
            {
                orderService.RemoveProductInOrder(orderId, productId);

                var orderDto = orderService.GetOrderDetails(orderId);
                var orderViewModel = MappingOrderDtoToOrderViewModel(orderDto);

                return View("GetOrderDetails", orderViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        private List<ProductForOrderViewModel> MappingProductsViewModelToProductsForOrderViewModel(List<ProductViewModel> productsViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, ProductForOrderViewModel>()
                    .ForMember(d => d.ProductId, m => m.MapFrom(s => s.Id)))
                    .CreateMapper();
            var productsForOrderViewModel = mapper.Map<List<ProductViewModel>, List<ProductForOrderViewModel>>(productsViewModel);

            return productsForOrderViewModel;
        }
        private OrderDto MappingOrderViewModelToOrderDto(OrderViewModel orderViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderViewModel, OrderDto>()).CreateMapper();
            var orderDto = mapper.Map<OrderViewModel, OrderDto>(orderViewModel);

            var productsDto = MappingProductsForOrderViewModelToProductsForOrderDto(orderViewModel.ProductsForOrderViewModel);
            orderDto.ProductsForOrderDto.AddRange(productsDto);

            return orderDto;
        }
        private OrderViewModel MappingOrderDtoToOrderViewModel(OrderDto orderDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDto, OrderViewModel>()).CreateMapper();
            var orderViewModel = mapper.Map<OrderDto, OrderViewModel>(orderDto);

            var productsForOrderViewModel = MappingProductsForOrderDtoToProductsForOrderViewModel(orderDto);
            orderViewModel.ProductsForOrderViewModel.AddRange(productsForOrderViewModel);

            return orderViewModel;
        }

        private List<OrderViewModel> MappingOrdersDtoToOrdersViewModel(List<OrderDto> ordersDto)
        {

            var ordersViewModel = new List<OrderViewModel>();
            foreach (var orderDto in ordersDto)
            {
                ordersViewModel.Add(MappingOrderDtoToOrderViewModel(orderDto));
            }

            return ordersViewModel;
        }
        private List<ProductForOrderDto> MappingProductsForOrderViewModelToProductsForOrderDto(List<ProductForOrderViewModel> productsForOrderViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductForOrderViewModel, ProductForOrderDto>()).CreateMapper();
            var productsForOrderDto = mapper.Map<List<ProductForOrderViewModel>, List<ProductForOrderDto>>(productsForOrderViewModel);
            return productsForOrderDto;
        }
        private List<ProductForOrderViewModel> MappingProductsForOrderDtoToProductsForOrderViewModel(OrderDto orderDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductForOrderDto, ProductForOrderViewModel>()).CreateMapper();
            var productsForOrderViewModel = mapper.Map<IEnumerable<ProductForOrderDto>, List<ProductForOrderViewModel>>(orderDto.ProductsForOrderDto);
            return productsForOrderViewModel;
        }
    }
}