using ITPLibrary.Web.Core.HttpClients.Interface;
using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IITPLibraryApiHttpClient _client;
        public IEnumerable<Category> Categories;

        public CategoryService(IITPLibraryApiHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _client.GetMany<IEnumerable<Category>>("api/categories");

            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _client.GetOne<Category>($"api/categories/{id}");

            return category;
        }
    }
}