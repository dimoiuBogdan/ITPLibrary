using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.Models;
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

        async Task<IEnumerable<Book>> IBookService.GetAllBooks(int? categoryId)
        {
            var uri = categoryId != null ? $"api/books/{categoryId}" : "api/books";

            var result = await _httpClient.GetAsync(uri);

            var json = await result.Content.ReadAsStringAsync();

            var deserializedResult = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            return deserializedResult;
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
