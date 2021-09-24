using ITPLibrary.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ITPLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : Controller
    {
        public IEnumerable<Book> Books;

        public BooksController()
        {
            Books = new List<Book>
                {
                    new Book{BookId=1, CategoryName="Fantasy", Title="Hobbit", ThumbnailUrl="https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fblogs.slj.com%2Fafuse8production%2Ffiles%2F2012%2F06%2FHobbit9.jpg&f=1&nofb=1", Description="An amazing fantasy book!", Author="JRR Tolkien", NumberOfPages=420, Price=50, IsPopular=true, Buyers=350},
                    new Book{BookId=2, CategoryName="SF", Title="Interstellar", ThumbnailUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.platekompaniet.no%2Fglobalassets%2Ffilmcover%2F2015%2Fmars%2Finterstellardvd.jpg&f=1&nofb=1", Description="To galaxy and beyond", Author="Cristopher Nolan", NumberOfPages=200, Price=30, IsPopular=true, Buyers=230},
                    new Book{BookId=3, CategoryName="Drama", Title="Recapitulare bac", ThumbnailUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FYC_MgG7s378%2Fmaxresdefault.jpg&f=1&nofb=1", Description="Sadness", Author="Invatamantul", NumberOfPages=999, Price=999, IsPopular=true, Buyers=999},
                    new Book{BookId=4, CategoryName="Fantasy", Title="Hobbit 2", ThumbnailUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.ictv.org.uk%2Fwp-content%2Fuploads%2F2013%2F01%2FThe-Hobbit.jpg&f=1&nofb=1", Description="An amazing fantasy book! 2", Author="JRR Tolkien", NumberOfPages=320, Price=50, IsPopular=false, Buyers=350},
                    new Book{BookId=5, CategoryName="SF", Title="Interstellar 2", ThumbnailUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pandatooth.com%2Fwp-content%2Fuploads%2F2016%2F03%2FInterstellar.jpg&f=1&nofb=1",Description="To galaxy and beyond 2", Author="Cristopher Nolan", NumberOfPages=300, Price=40, IsPopular=false, Buyers=230},
                    new Book{BookId=6, CategoryName="Drama", Title="Recapitulare bac 2", ThumbnailUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.christianartgifts.com%2Fproduct-images%2FKJV019_5--featureA.jpg%3Fresizeid%3D5%26resizeh%3D1200%26resizew%3D1200&f=1&nofb=1",Description="Sadness 2", Author="Invatamantul", NumberOfPages=399, Price=499, IsPopular=false, Buyers=999}
                };
        }

        public IEnumerable<Book> GetAllBooks(string category)
        {
            if (category == null) 
            {
                return Books;
            }
            return Books.Where(book => book.CategoryName == category);
        }

        [HttpGet("popular")]
        public IEnumerable<Book> GetPopularBooks()
        {
            return Books.Where(book => book.IsPopular == true);
        }

        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
            return Books.FirstOrDefault(book => book.BookId == id);
        }
    }
}
