using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Web
{
    public class BookController : Controller
    {
        private readonly IBookService _bookRepository;

        public BookController(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult List(string category)
        {
            return View(_bookRepository.GetAllBooks(category).Result);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id).Result;
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
