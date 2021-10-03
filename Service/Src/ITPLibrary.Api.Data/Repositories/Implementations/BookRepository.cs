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

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(book => book.BookId == id);
        }

        public async Task<IEnumerable<Book>> GetBooks([Optional] string category)
        {
            if (category != null) 
            {
                return await _appDbContext.Books.Where(book => book.CategoryName == category).ToListAsync();
            }
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetPopularBooks()
        {
            return await _appDbContext.Books.Where(b => b.IsPopular).ToListAsync();
        }
    }
}
