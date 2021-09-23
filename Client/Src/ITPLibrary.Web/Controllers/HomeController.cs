using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookRepository;

        public HomeController(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PopularBooks = _bookRepository.GetPopularBooks().Result
            };

            return View(homeViewModel);
        }
    }
}
