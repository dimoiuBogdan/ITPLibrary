using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;

namespace ITPLibrary.Web.Core.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        public string Title { get; set; }
    }
}
