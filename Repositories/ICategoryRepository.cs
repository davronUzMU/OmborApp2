using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategoryAll();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        Category EditCategory(Category category);
        void DeleteCategory(int id);
    }
}
