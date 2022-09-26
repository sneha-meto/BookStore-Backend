using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface ICategory
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
    }
}