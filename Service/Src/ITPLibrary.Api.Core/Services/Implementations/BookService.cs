using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.Interfaces;
using ITPLibrary.Api.Data.Entities;
using ITPLibrary.Api.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services.Implementations
{
    public class BookService : IBookService
    {
        public IBookRepository _bookRepository;
        public IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks(string category)
        {
            var books = await _bookRepository.GetBooks(category);

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetPopularBooks()
        {
            var books = await _bookRepository.GetPopularBooks();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<int> CreateNewBook(BookCreateDto bookDto)
        {
            var book = new Book();
            // Mapam bookDto la book ca sa aiba property de id
            var id = await _bookRepository.CreateNewBook(_mapper.Map(bookDto, book));

            return id;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.DeleteBook(id);

            return bookToDelete;
        }

        public async Task<BookDto> EditBook(BookEditDto editedBook, int id)
        {
            var bookToEdit = await _bookRepository.GetBookById(id);

             _mapper.Map(editedBook, bookToEdit);

            var updatedBook = await _bookRepository.EditBook(bookToEdit, id);

            return _mapper.Map<BookDto>(updatedBook);
        }
    }
}
