using AutoMapper;
using ITPLibrary.Api.Data.Data;
using ITPLibrary.Api.Data.Entities;
using ITPLibrary.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public BookRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(book => book.BookId == id);
        }

        public async Task<IEnumerable<Book>> GetBooks([Optional] string category)
        {
            if (category != null)
            {
                var books = await _appDbContext.Books.Where(book => book.Category.CategoryName == category).ToListAsync();
                return books;
            }
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetPopularBooks()
        {
            return await _appDbContext.Books.Where(b => b.IsPopular).ToListAsync();
        }

        public async Task<int> CreateNewBook(Book book)
        {
            // Aici se atribuie urmatorul id valabil
            await _appDbContext.Books.AddAsync(book);

            _appDbContext.SaveChanges();

            return book.BookId;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToDelete = await _appDbContext.Books.FirstOrDefaultAsync(book => book.BookId == id);

            if (bookToDelete != null)
            {

                var removed = _appDbContext.Books.Remove(bookToDelete);

                await _appDbContext.SaveChangesAsync();

                if (removed != null)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public async Task<Book> EditBook(Book editedBook, int id)
        {
            _appDbContext.Update(editedBook);

            await _appDbContext.SaveChangesAsync();

            return editedBook;
        }
    }
}