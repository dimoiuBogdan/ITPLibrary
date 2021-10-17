using ITPLibrary.Web.Core.Service.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<IActionResult> Edit(int id)
        {
            var bookToEdit = _bookService.GetBookById(id).Result;

            var model = await _bookService.EditBookModel(bookToEdit);

            return View(model);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditBook(NewBookViewModel book, int id)
        {
            if (ModelState.IsValid)
            {
                await _bookService.EditBook(book, id);

                var result = RedirectToAction("details", new { id });

                return result;
            }
            // Error
            return await Edit(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(NewBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookService.AddBook(book);

                var result = RedirectToAction("details", new { id });

                return result;
            }
            // Error
            return await Add();
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