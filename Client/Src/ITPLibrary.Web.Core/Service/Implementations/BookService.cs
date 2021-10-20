using AutoMapper;
using ITPLibrary.Web.Core.Dtos;
using ITPLibrary.Web.Core.HttpClients.Interface;
using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.Service.Interfaces;
using ITPLibrary.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

            var books = await _client.GetMany<IEnumerable<BookModel>>(uri);

            var booksListViewModel = new BooksListViewModel()
            {
                Books = books,
                Title = categoryName == null ? "Welcome to our book list" : $"{categoryName} books"
            };

            return booksListViewModel;
        }

        public async Task<HomeViewModel> GetPopularBooks()
        {
            var popularBooks = await _client.GetMany<IEnumerable<BookModel>>("api/books/popular");

            var homeViewModel = new HomeViewModel()
            {
                PopularBooks = popularBooks
            };

            return homeViewModel;
        }

        public async Task<BookModel> GetBookById(int bookId)
        {
            var book = await _client.GetOne<BookModel>($"api/books/{bookId}");

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
            var categories = await _client.GetMany<IEnumerable<CategoryModel>>("api/categories");

            var newBookViewModel = new NewBookViewModel();

            newBookViewModel.Categories = new List<SelectListItem>(categories.Select(category => new SelectListItem()
            {
                Text = category.CategoryName,
                Value = category.CategoryId.ToString()
            }));

            return newBookViewModel;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var isBookDeleted = await _client.Delete<bool>($"api/books/{id}");

            return isBookDeleted;
        }
        
        public async Task<EditBookViewModel> EditBookModel(BookModel bookToEdit)
        {
            var categories = await _client.GetMany<IEnumerable<CategoryModel>>("api/categories");

            var editBookViewModel = new EditBookViewModel();

            _mapper.Map(bookToEdit, editBookViewModel);

            editBookViewModel.Categories = new List<SelectListItem>(categories.Select(category => new SelectListItem()
            {
                Text = category.CategoryName,
                Value = category.CategoryId.ToString()
            }));

            return editBookViewModel;
        }

        public async Task<BookModel> EditBook(EditBookViewModel book, int bookToEditId)
        {
            var bookEditDto = new BookEditDto();

            _mapper.Map(book, bookEditDto);

            var editedBook = await _client.Patch<BookModel, BookEditDto>(bookEditDto, $"api/books/{bookToEditId}");

            return editedBook;
        }
    }
}


