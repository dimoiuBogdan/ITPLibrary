using ITPLibrary.Web.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetPopularBooks().Result);
        }
    }
}
