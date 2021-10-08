using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ITPLibrary.Web.Core.ViewModels
{
    public class NewBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public string ThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
