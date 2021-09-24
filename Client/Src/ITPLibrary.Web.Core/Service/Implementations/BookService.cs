using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Implementations
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        async Task<BooksListViewModel> IBookService.GetAllBooks(string categoryName)
        {
            var uri = categoryName != null ? $"api/books?category={categoryName}" : "api/books";

            var result = await _httpClient.GetAsync(uri);

            var json = await result.Content.ReadAsStringAsync();

            var deserializedResult = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            var booksListViewModel = new BooksListViewModel()
            {
                Books = deserializedResult,
                Title = categoryName == null ? "Welcome to our book list" : $"{categoryName} books"
            };

            return booksListViewModel;
        }

        async Task<IEnumerable<Book>> IBookService.GetPopularBooks()
        {
            var result = await _httpClient.GetAsync("api/books/popular");

            var json = await result.Content.ReadAsStringAsync();

            var deserializedResult = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            return deserializedResult;
        }

        async Task<Book> IBookService.GetBookById(int bookId)
        {
            var result = await _httpClient.GetAsync($"api/books/{bookId}");

            var json = await result.Content.ReadAsStringAsync();

            var deserializedResult = JsonConvert.DeserializeObject<Book>(json);

            return deserializedResult;
        }
    }
}
