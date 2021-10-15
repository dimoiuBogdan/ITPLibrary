using AutoMapper;
using ITPLibrary.Web.Core.Dtos;
using ITPLibrary.Web.Core.HttpClients.Interface;
using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.Service.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Implementations
{
    public class BookService : IBookService
    {
        private readonly IITPLibraryApiHttpClient _client;
        private readonly IMapper _mapper;

        public BookService(IITPLibraryApiHttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        // Oricand fac o metoda async ( sau ceva asyncron ) folosim tip Task<T>
        public async Task<BooksListViewModel> GetAllBooks(string categoryName)
        {
            var uri = categoryName != null ? $"api/books?category={categoryName}" : "api/books";

            var books = await _client.GetMany<IEnumerable<Book>>(uri);

            var booksListViewModel = new BooksListViewModel()
            {
                Books = books,
                Title = categoryName == null ? "Welcome to our book list" : $"{categoryName} books"
            };

            return booksListViewModel;
        }

        public async Task<HomeViewModel> GetPopularBooks()
        {
            var popularBooks = await _client.GetMany<IEnumerable<Book>>("api/books/popular");

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

        public async Task<int> AddBook(NewBookViewModel book)
        {
            var bookCreateDto = new BookCreateDto();

            _mapper.Map(book, bookCreateDto);

            var newBookId = await _client.Post<int, BookCreateDto>(bookCreateDto, "api/books");

            return newBookId;
        }

        public async Task<NewBookViewModel> AddBookModel()
        {
            var categories = await _client.GetMany<IEnumerable<Category>>("api/categories");

            var res = new NewBookViewModel();

            res.Categories = new List<SelectListItem>(categories.Select(category => new SelectListItem()
            {
                Text = category.CategoryName,
                Value = category.CategoryId.ToString()
            }));

            return res;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToDelete = await _client.Delete<bool>($"api/books/{id}");

            return bookToDelete;
        }

        public async Task<EditBookViewModel> EditBookModel(Book bookToEdit)
        {
            var categories = await _client.GetMany<IEnumerable<Category>>("api/categories");

            var res = new EditBookViewModel();

            if (bookToEdit.BookId != 0)
                res.BookId = bookToEdit.BookId;
            if (bookToEdit.Author != null)
                res.Author = bookToEdit.Author;
            if (bookToEdit.Category != null)
                res.Category = bookToEdit.Category;
            if (bookToEdit.Description != null)
                res.Description = bookToEdit.Description;
            if (bookToEdit.Title != null)
                res.Title = bookToEdit.Title;
            if (bookToEdit.Price != 0)
                res.Price = (decimal)(bookToEdit.Price);
            if (bookToEdit.ThumbnailUrl != null)
                res.ThumbnailUrl = bookToEdit.ThumbnailUrl;
            if (bookToEdit.NumberOfPages != 0)
                res.NumberOfPages = (int)(bookToEdit.NumberOfPages);

            res.Categories = new List<SelectListItem>(categories.Select(category => new SelectListItem()
            {
                Text = category.CategoryName,
                Value = category.CategoryId.ToString()
            }));

            return res;
        }

        public async Task<Book> EditBook(NewBookViewModel book, int bookToEditId)
        {
            var bookCreateDto = new BookCreateDto();

            _mapper.Map(book, bookCreateDto);

            var editedBook = await _client.Patch<Book, BookCreateDto>(bookCreateDto, $"api/books/{bookToEditId}");

            return editedBook;
        }
    }
}


