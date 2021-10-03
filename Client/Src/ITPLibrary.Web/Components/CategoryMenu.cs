using ITPLibrary.Web.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ITPLibrary.Web.Controllers
{
    public class CategoryMenu : ViewComponent
    {
        public readonly ICategoryService _categoryService;

        public CategoryMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.AllCategories().OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
