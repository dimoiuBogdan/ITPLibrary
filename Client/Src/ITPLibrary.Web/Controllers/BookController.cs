using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.Models;
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
            BooksListViewModel booksListViewModel = new BooksListViewModel();
            booksListViewModel.Books = _bookRepository.GetAllBooks(category).Result;

            return View(booksListViewModel);
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
