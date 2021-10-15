using ITPLibrary.Api.Data.Entities;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks([Optional] string category);
        Task<IEnumerable<Book>> GetPopularBooks();
        Task<Book> GetBookById(int id);
        Task<int> CreateNewBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<Book> EditBook(Book book, int id);
    }
}
