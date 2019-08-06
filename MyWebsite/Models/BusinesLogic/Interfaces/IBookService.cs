using MyWebsite.Models.BusinesLogic.DataTransfer;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IBookService
    {
        int Create(BookDto bookDto);
        List<ProductDto> GetBooks();
        BookDto GetBook(int bookId);
        void Update(BookDto bookDto);
        void Dispose();
    }
}
