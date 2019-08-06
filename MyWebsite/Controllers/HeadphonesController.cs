using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Infrastructure;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class HeadphonesController : Controller
    {
        IHeadphonesService headphonesService;
        public HeadphonesController(IHeadphonesService services)
        {
            headphonesService = services;
        }
        public ActionResult GetHeadphones(int headphonesId)
        {
            try
            {
                var headphonesDto = headphonesService.GetHeadphones(headphonesId);
                var headphonesViewModel = MappingHeadphonesDtoToHeadphonesViewModel(headphonesDto);
                return View(headphonesViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetHeadphonesSets()
        {
            try
            {
                var productsDto = headphonesService.GetHeadphonesSets();
                var ordersViewModel = MappingProductsDtoToProductsViewModel(productsDto);
                return View(ordersViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public ActionResult CreateHeadphones()
        {
            try
            {
                return View();
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult CreateHeadphones(HeadphonesViewModel headphonesViewModel, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (ModelState.IsValid && uploadImage != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }

                    HeadphonesDto headphonesDto = MappingHeadphonesViewModelToHeadphonesDto(headphonesViewModel);
                    headphonesDto.Image = imageData;
                    int headphonesId = headphonesService.Create(headphonesDto);

                    return RedirectToAction("CreateHeadphonesSuccess", new { headphonesId });
                }
                return View(headphonesViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreateHeadphonesSuccess(int headphonesId)
        {
            try
            {
                var headphonesDto = headphonesService.GetHeadphones(headphonesId);
                var headphonesViewModel = MappingHeadphonesDtoToHeadphonesViewModel(headphonesDto);
                return View(headphonesViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
        public ActionResult EditHeadphones(int headphonesId)
        {
            try
            {
                var headphonesDto = headphonesService.GetHeadphones(headphonesId);
                var headphonesViewModel = MappingHeadphonesDtoToHeadphonesViewModel(headphonesDto);
                return View(headphonesViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult EditHeadphones(HeadphonesViewModel headphonesViewModel, HttpPostedFileBase uploadImage)
        {
            try
            {
                HeadphonesDto headphonesDto = MappingHeadphonesViewModelToHeadphonesDto(headphonesViewModel);

                if (uploadImage != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    headphonesDto.Image = imageData;
                }
                else
                {
                    headphonesDto.Image = null;
                }


                headphonesService.Update(headphonesDto);

                HeadphonesDto headphonesDtoUpdated = headphonesService.GetHeadphones(headphonesDto.Id);

                var headphonesViewModelUpdated = MappingHeadphonesDtoToHeadphonesViewModel(headphonesDtoUpdated);
                return View("CreateHeadphonesSuccess", headphonesViewModelUpdated);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        private HeadphonesDto MappingHeadphonesViewModelToHeadphonesDto(HeadphonesViewModel headphonesViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeadphonesViewModel, HeadphonesDto>()).CreateMapper();
            var headphonesDto = mapper.Map<HeadphonesViewModel, HeadphonesDto>(headphonesViewModel);
            return headphonesDto;
        }

        private HeadphonesViewModel MappingHeadphonesDtoToHeadphonesViewModel(HeadphonesDto headphonesDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeadphonesDto, HeadphonesViewModel>()).CreateMapper();
            var headphonesViewModel = mapper.Map<HeadphonesDto, HeadphonesViewModel>(headphonesDto);
            return headphonesViewModel;
        }

        private List<ProductViewModel> MappingProductsDtoToProductsViewModel(List<ProductDto> productsDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductViewModel>()).CreateMapper();
            var productsViewModel = mapper.Map<List<ProductDto>, List<ProductViewModel>>(productsDto);
            return productsViewModel;
        }
    }
}