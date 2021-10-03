using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.Interfaces;
using ITPLibrary.Api.Data.Entities;
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

        [HttpGet("popular")]
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
        public IActionResult PostBook([FromBody] Book book)
        {
            return CreatedAtRoute("GetBook", new { id = book.BookId }, book);
        }
    }
}
