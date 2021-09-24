using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.ViewModels;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Interfaces
{
    public interface IBookService
    {
        Task<BooksListViewModel> GetAllBooks([Optional] string category);
        Task<IEnumerable<Book>> GetPopularBooks();
        Task<Book> GetBookById(int bookId);
    }
}
