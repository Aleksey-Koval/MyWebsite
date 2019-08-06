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
    public class TvController : Controller
    {
        ITvService tvService;
        public TvController(ITvService services)
        {
            tvService = services;
        }
        public ActionResult GetTv(int tvId)
        {
            try
            {
                var tvDto = tvService.GetTv(tvId);
                var tvViewModel = MappingTvDtoToTvViewModel(tvDto);
                return View(tvViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult GetTvSets()
        {
            try
            {
                var productsDto = tvService.GetTvSets();
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
        public ActionResult CreateTv()
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
        public ActionResult CreateTv(TvViewModel tvViewModel, HttpPostedFileBase uploadImage)
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

                    TvDto tvDto = MappingTvViewModelToTvDto(tvViewModel);
                    tvDto.Image = imageData;
                    int tvId = tvService.Create(tvDto);

                    return RedirectToAction("CreateTvSuccess", new { tvId });
                }
                return View(tvViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreateTvSuccess(int tvId)
        {
            try
            {
                var tvDto = tvService.GetTv(tvId);
                var tvViewModel = MappingTvDtoToTvViewModel(tvDto);
                return View(tvViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public ActionResult EditTv(int tvId)
        {
            try
            {
                var tvDto = tvService.GetTv(tvId);
                var tvViewModel = MappingTvDtoToTvViewModel(tvDto);
                return View(tvViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult EditTv(TvViewModel tvViewModel, HttpPostedFileBase uploadImage)
        {
            try
            {
                TvDto tvDto = MappingTvViewModelToTvDto(tvViewModel);

                if (uploadImage != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    tvDto.Image = imageData;
                }
                else
                {
                    tvDto.Image = null;
                }


                tvService.Update(tvDto);

                TvDto tvDtoUpdated = tvService.GetTv(tvDto.Id);

                var tvViewModelUpdated = MappingTvDtoToTvViewModel(tvDtoUpdated);
                return View("CreateTvSuccess", tvViewModelUpdated);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        private TvDto MappingTvViewModelToTvDto(TvViewModel tvViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TvViewModel, TvDto>()).CreateMapper();
            var tvDto = mapper.Map<TvViewModel, TvDto>(tvViewModel);
            return tvDto;
        }

        private TvViewModel MappingTvDtoToTvViewModel(TvDto tvDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TvDto, TvViewModel>()).CreateMapper();
            var tvViewModel = mapper.Map<TvDto, TvViewModel>(tvDto);
            return tvViewModel;
        }

        private List<ProductViewModel> MappingProductsDtoToProductsViewModel(List<ProductDto> productsDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductViewModel>()).CreateMapper();
            var productsViewModel = mapper.Map<List<ProductDto>, List<ProductViewModel>>(productsDto);
            return productsViewModel;
        }
    }
}
