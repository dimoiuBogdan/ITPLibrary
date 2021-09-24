using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
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
            var homeViewModel = new HomeViewModel
            {
                PopularBooks = _bookService.GetPopularBooks().Result
            };

            return View(homeViewModel);
        }
    }
}
