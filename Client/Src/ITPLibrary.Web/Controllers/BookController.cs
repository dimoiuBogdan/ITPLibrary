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
            var books = _bookService.GetAllBooks(category).Result;

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id).Result;

            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bookToEdit = _bookService.GetBookById(id).Result;

            var model = await _bookService.EditBookModel(bookToEdit);

            return View(model);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditBook(int id, EditBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.EditBook(book, id);

                return RedirectToAction("details", new { id });
            }

            var bookToEdit = _bookService.GetBookById(id).Result;
            return View("Edit", await _bookService.EditBookModel(bookToEdit));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(NewBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookService.AddBook(book);

                return RedirectToAction("details", new { id });
            }
            return View("Add", await _bookService.AddBookModel());
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

            return RedirectToAction("list"); ;
        }
    }
}