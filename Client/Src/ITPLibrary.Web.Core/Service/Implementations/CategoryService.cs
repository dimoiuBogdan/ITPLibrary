using ITPLibrary.Web.Core.Interfaces;
using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace ITPLibrary.Web.Core.Implementations
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fantasy", Description="Fantasy books"},
                new Category{CategoryId=2, CategoryName="SF", Description="SF books"},
                new Category{CategoryId=3, CategoryName="Drama", Description="Drama books"},
                new Category{CategoryId=4, CategoryName="Most popular books", Description="Our best selection just for you!"},
            };

        public Category GetCategoryByName(string query)
        {
            return AllCategories.FirstOrDefault(category => category.CategoryName.Contains(query));
        }
    }
}
