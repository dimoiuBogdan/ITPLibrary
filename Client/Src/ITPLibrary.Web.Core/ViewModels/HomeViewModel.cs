using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;

namespace ITPLibrary.Web.Core.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BookModel> PopularBooks { get; set; }
    }
}