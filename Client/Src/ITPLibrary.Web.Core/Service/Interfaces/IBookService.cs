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
        Task<BookModel> GetBookById(int bookId);
        Task<int> AddBook(NewBookViewModel book);
        Task<NewBookViewModel> AddBookModel();
        Task<bool> DeleteBook(int id);
        Task<BookModel> EditBook(EditBookViewModel book, int bookToEditId);
        Task<EditBookViewModel> EditBookModel(BookModel bookToEdit);
    }
}
