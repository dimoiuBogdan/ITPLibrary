using ITPLibrary.Api.Core.Dtos;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooks([Optional] string category);
        Task<IEnumerable<BookDto>> GetPopularBooks();
        Task<BookDto> GetBookById(int bookId);
        Task<int> CreateNewBook(BookCreateDto book);
        Task<bool> DeleteBook(int id);
    }
}
