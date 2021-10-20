using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : Controller
    {
        public IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks(string category)
        {
            var books = await _bookService.GetAllBooks(category);
            return books;
        }

        [HttpGet("popular", Name = "GetPopularBooks")]
        public async Task<IEnumerable<BookDto>> GetPopularBooks()
        {
            var books = await _bookService.GetPopularBooks();
            return books;
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<BookDto> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            return book;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBook(BookCreateDto book)
        {
            // De aici pleaca "book" populat cu datele din form
            var id = await _bookService.CreateNewBook(book);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var isOkay = await _bookService.DeleteBook(id);

            if (isOkay)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(int id, BookEditDto editedBook)
        {
            var bookToEdit = await _bookService.EditBook(editedBook, id);

            return Ok(bookToEdit);
        }
    }
}

// HTTP W3Schools