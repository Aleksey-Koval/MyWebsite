using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class BookService : IBookService
    {
        IUnitOfWork Database { get; set; }

        public BookService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public int Create(BookDto bookDto)
        {
            Book book = MappingBookDtoToBook(bookDto);
            Database.Books.Create(book);
            Database.Save();
            return book.Id;
        }


        public BookDto GetBook(int bookId)
        {
            Book book = Database.Books.Get(bookId);
            BookDto bookDto = MappingBookToBookDto(book);
            return bookDto;
        }

        public List<ProductDto> GetBooks()
        {
            var books = Database.Books.GetAll();
            var productsDto = MappingBooksToProductsDto(books);
            return productsDto;
        }

        public void Update(BookDto bookDto)
        {
            Book book = Database.Books.Get(bookDto.Id);

            book.Name = bookDto.Name;
            book.Author = bookDto.Author;
            book.Genre = bookDto.Genre;
            book.PublishingHouse = bookDto.PublishingHouse;
            book.YearOfPublishing = bookDto.YearOfPublishing;
            book.Annotation = bookDto.Annotation;
            if (bookDto.Image != null)
                book.Image = bookDto.Image;
            if (bookDto.Price != 0)
                book.Price = bookDto.Price;

            Database.Books.Update(book);
            Database.Save();
        }

        private BookDto MappingBookToBookDto(Book book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>()).CreateMapper();
            var bookDto = mapper.Map<Book, BookDto>(book);
            return bookDto;
        }

        private Book MappingBookDtoToBook(BookDto bookDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDto, Book>()).CreateMapper();
            var book = mapper.Map<BookDto, Book>(bookDto);
            return book;
        }

        private List<ProductDto> MappingBooksToProductsDto(IEnumerable<Book> books)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, ProductDto>()).CreateMapper();
            var productsDto = mapper.Map<IEnumerable<Book>, List<ProductDto>>(books);
            return productsDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}