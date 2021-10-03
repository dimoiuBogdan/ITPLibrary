using ITPLibrary.Web.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return View(_bookService.GetBookById(id).Result);
        }
    }
}
