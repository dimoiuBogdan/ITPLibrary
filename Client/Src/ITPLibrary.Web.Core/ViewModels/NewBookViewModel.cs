using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITPLibrary.Web.Core.ViewModels
{
    public class NewBookViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Number of pages is required")]
        public int NumberOfPages { get; set; }
        [Required(ErrorMessage = "Thumbnail is required")]
        public string ThumbnailUrl { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
