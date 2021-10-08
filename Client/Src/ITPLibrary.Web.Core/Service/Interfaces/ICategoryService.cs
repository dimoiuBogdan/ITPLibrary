﻿using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}
