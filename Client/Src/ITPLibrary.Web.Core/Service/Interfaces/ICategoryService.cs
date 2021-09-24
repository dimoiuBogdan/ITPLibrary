using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;

namespace ITPLibrary.Web.Core.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> AllCategories();
    }
}
