using WinFormsApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Models.Category> GetCategoryAll() => _categoryRepository.GetCategoryAll();
        public Models.Category AddCategory(string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            var category2 = new Models.Category
            {
                CategoryName = category,
                CreatedAt = DateTime.UtcNow,
            };
            var category3 = _categoryRepository.AddCategory(category2);
            return category3;
        }
        public void DeleteCategory(int id) => _categoryRepository.DeleteCategory(id);

        public void UpdateCategory(Models.Category category) {
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            var category2 = _categoryRepository.GetCategoryById(category.Id);
            category2.CategoryName = category.CategoryName;
            category2.CreatedAt = DateTime.UtcNow;
            _categoryRepository.EditCategory(category2);
        }
    }
}
