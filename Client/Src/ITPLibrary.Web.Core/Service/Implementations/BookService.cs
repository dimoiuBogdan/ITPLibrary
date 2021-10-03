using ITPLibrary.Web.Core.HttpClients.Interface;
using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.Service.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Implementations
{
    public class BookService : IBookService
    {
        private readonly IITPLibraryApiHttpClient _client;

        public BookService(IITPLibraryApiHttpClient client)
        {
            _client = client;
        }

        // Oricand fac o metoda async ( sau ceva asyncron ) folosim tip Task<T>
        public async Task<BooksListViewModel> GetAllBooks(string categoryName)
        {
            var uri = categoryName != null ? $"api/books?category={categoryName}" : "api/books";

            var books = await _client.GetMany<Book>(uri);

            var booksListViewModel = new BooksListViewModel()
            {
                Books = books,
                Title = categoryName == null ? "Welcome to our book list" : $"{categoryName} books"
            };

            return booksListViewModel;
        }

        public async Task<HomeViewModel> GetPopularBooks()
        {
            var popularBooks = await _client.GetMany<Book>("api/books/popular");

            var homeViewModel = new HomeViewModel()
            {
                PopularBooks = popularBooks
            };

            return homeViewModel;
        }

        public async Task<Book> GetBookById(int bookId)
        {
            var book = await _client.GetOne<Book>($"api/books/{bookId}");

            return book;
        }

        //public async Task<bool> PostBook(Book book)
        //{
        //    var post = await _client.Post(book, "api/books");

        //    return post;
        //}
    }
}


