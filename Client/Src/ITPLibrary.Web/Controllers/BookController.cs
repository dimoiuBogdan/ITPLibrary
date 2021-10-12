using ITPLibrary.Web.Core.Service.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITPLibrary.Web
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ViewResult List(string category)
        {
            return View(_bookService.GetAllBooks(category).Result);
        }

        public IActionResult Details(int id)
        {
            var result = _bookService.GetBookById(id).Result;

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(NewBookViewModel book)
        {
            var id = await _bookService.AddBook(book);

            var result = RedirectToAction("details", new { id });

            return result;
        }

        public async Task<IActionResult> Add()
        {
            var model = await _bookService.AddBookModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);

            var result = RedirectToAction("list");

            return result;
        }
    }
}
