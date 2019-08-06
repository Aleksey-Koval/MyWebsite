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
    public class BookController : Controller
    {
        IBookService bookService;
        public BookController(IBookService services)
        {
            bookService = services;
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            try
            {
                var productsDto = bookService.GetBooks();
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
        public ActionResult CreateBook()
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
        public ActionResult CreateBook(BookViewModel bookViewModel, HttpPostedFileBase uploadImage)
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

                    BookDto bookDto = MappingBookViewModelToBookDto(bookViewModel);
                    bookDto.Image = imageData;
                    int bookId = bookService.Create(bookDto);

                    return RedirectToAction("CreateBookSuccess", new { bookId });
                }
                return View(bookViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreateBookSuccess(int bookId)
        {
            try
            {
                var bookDto = bookService.GetBook(bookId);
                var bookViewModel = MappingBookDtoToBookViewModel(bookDto);
                return View(bookViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public ActionResult EditBook(int bookId)
        {
            try
            {
                var bookDto = bookService.GetBook(bookId);
                var bookViewModel = MappingBookDtoToBookViewModel(bookDto);
                return View(bookViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult EditBook(BookViewModel bookViewModel, HttpPostedFileBase uploadImage)
        {
            try
            {
                BookDto bookDto = MappingBookViewModelToBookDto(bookViewModel);

                if (uploadImage != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    bookDto.Image = imageData;
                }
                else
                {
                    bookDto.Image = null;
                }

                bookService.Update(bookDto);
                BookDto bookDtoUpdated = bookService.GetBook(bookDto.Id);
                var bookViewModelUpdated = MappingBookDtoToBookViewModel(bookDtoUpdated);
                return View("CreateBookSuccess", bookViewModelUpdated);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult GetBook(int bookId)
        {
            try
            {
                var bookDto = bookService.GetBook(bookId);
                var bookViewModel = MappingBookDtoToBookViewModel(bookDto);
                return View(bookViewModel);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        private BookDto MappingBookViewModelToBookDto(BookViewModel bookViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, BookDto>()).CreateMapper();
            var bookDto = mapper.Map<BookViewModel, BookDto>(bookViewModel);
            return bookDto;
        }

        private BookViewModel MappingBookDtoToBookViewModel(BookDto bookDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDto, BookViewModel>()).CreateMapper();
            var bookViewModel = mapper.Map<BookDto, BookViewModel>(bookDto);
            return bookViewModel;
        }

        private List<ProductViewModel> MappingProductsDtoToProductsViewModel(List<ProductDto> productsDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductViewModel>()).CreateMapper();
            var productsViewModel = mapper.Map<List<ProductDto>, List<ProductViewModel>>(productsDto);
            return productsViewModel;
        }
    }
}