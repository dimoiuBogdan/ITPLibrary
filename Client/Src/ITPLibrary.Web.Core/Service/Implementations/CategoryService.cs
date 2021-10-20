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
        public IEnumerable<CategoryModel> Categories;

        public CategoryService(IITPLibraryApiHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categories = await _client.GetMany<IEnumerable<CategoryModel>>("api/categories");

            return categories;
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var category = await _client.GetOne<CategoryModel>($"api/categories/{id}");

            return category;
        }
    }
}