using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks([Optional] string category);
        Task<IEnumerable<Book>> GetPopularBooks();
        Task<Book> GetBookById(int bookId);
    }
}
