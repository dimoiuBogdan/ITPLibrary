using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.Interfaces;
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
    }
}
