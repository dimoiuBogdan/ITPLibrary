using ITPLibrary.Api.Core.Services.Interfaces;
using ITPLibrary.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories =await _categoryService.GetCategories();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryById(id);
        }

    }
}
