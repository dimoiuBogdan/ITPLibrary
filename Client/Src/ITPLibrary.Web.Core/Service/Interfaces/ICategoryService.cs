using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategoryById(int id);
    }
}
