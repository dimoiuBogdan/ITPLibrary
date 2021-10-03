using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.ViewModels;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Service.Interfaces
{
    public interface IBookService
    {
        Task<BooksListViewModel> GetAllBooks([Optional] string category);
        Task<HomeViewModel> GetPopularBooks();
        Task<Book> GetBookById(int bookId);
    }
}
