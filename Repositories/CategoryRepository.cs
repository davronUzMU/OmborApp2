using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public Category EditCategory(Category category)
        {
            _context.Categories.Update(category);  
            _context.SaveChanges();
            return category;
        }

        public List<Category> GetCategoryAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
    }
}
