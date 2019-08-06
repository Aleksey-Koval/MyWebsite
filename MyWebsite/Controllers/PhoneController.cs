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
    public class PhoneController : Controller
    {
        IPhoneService phoneService;
        public PhoneController(IPhoneService services)
        {
            phoneService = services;
        }

        public ActionResult GetPhone(int phoneId)
        {
            try
            {
                var phoneDto = phoneService.GetPhone(phoneId);
                var phoneViewModel = MappingPhoneDtoToPhoneViewModel(phoneDto);
                return View(phoneViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetPhones()
        {
            try
            {
                var productsDto = phoneService.GetPhones();
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
        public ActionResult CreatePhone()
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
        public ActionResult CreatePhone(PhoneViewModel phoneViewModel, HttpPostedFileBase uploadImage)
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

                    PhoneDto phoneDto = MappingPhoneViewModelToPhoneDto(phoneViewModel);
                    phoneDto.Image = imageData;
                    int phoneId = phoneService.Create(phoneDto);

                    return RedirectToAction("CreatePhoneSuccess", new { phoneId });
                }
                return View(phoneViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreatePhoneSuccess(int phoneId)
        {
            try
            {
                var phoneDto = phoneService.GetPhone(phoneId);
                var phoneViewModel = MappingPhoneDtoToPhoneViewModel(phoneDto);
                return View(phoneViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public ActionResult EditPhone(int phoneId)
        {
            try
            {
                var phoneDto = phoneService.GetPhone(phoneId);
                var phoneViewModel = MappingPhoneDtoToPhoneViewModel(phoneDto);
                return View(phoneViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult EditPhone(PhoneViewModel phoneViewModel, HttpPostedFileBase uploadImage)
        {
            try
            {
                PhoneDto phoneDto = MappingPhoneViewModelToPhoneDto(phoneViewModel);

                if (uploadImage != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    phoneDto.Image = imageData;
                }
                else
                {
                    phoneDto.Image = null;
                }


                phoneService.Update(phoneDto);

                PhoneDto phoneDtoUpdated = phoneService.GetPhone(phoneDto.Id);

                var phoneViewModelUpdated = MappingPhoneDtoToPhoneViewModel(phoneDtoUpdated);
                return View("CreatePhoneSuccess", phoneViewModelUpdated);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        private PhoneDto MappingPhoneViewModelToPhoneDto(PhoneViewModel phoneViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneViewModel, PhoneDto>()).CreateMapper();
            var phoneDto = mapper.Map<PhoneViewModel, PhoneDto>(phoneViewModel);
            return phoneDto;
        }

        private PhoneViewModel MappingPhoneDtoToPhoneViewModel(PhoneDto phoneDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneDto, PhoneViewModel>()).CreateMapper();
            var phoneViewModel = mapper.Map<PhoneDto, PhoneViewModel>(phoneDto);
            return phoneViewModel;
        }

        private List<ProductViewModel> MappingProductsDtoToProductsViewModel(List<ProductDto> productsDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductViewModel>()).CreateMapper();
            var productsViewModel = mapper.Map<List<ProductDto>, List<ProductViewModel>>(productsDto);
            return productsViewModel;
        }
    }
}