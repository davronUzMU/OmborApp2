using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class ProductHouseholdRepository : IProductHouseholdRepository
    {
        private readonly AppDbContext _context;
        public ProductHouseholdRepository(AppDbContext context)
        {
            _context = context;
        }
        public ProductHousehold AddProductHH(ProductHousehold productHousehold)
        {
            _context.ProductHouseholds.Add(productHousehold);
            _context.SaveChanges();
            return productHousehold;
        }

        public void DeleteProductHH(int id)
        {
            var productHousehold = _context.ProductHouseholds.Find(id);
            if (productHousehold != null)
            {
                _context.ProductHouseholds.Remove(productHousehold);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductHousehold EditProductHH(ProductHousehold productHousehold)
        {
            _context.ProductHouseholds.Update(productHousehold);
            _context.SaveChanges();
            return productHousehold;
        }

        public List<ProductHousehold> GetProductHHAll()
        {
            return _context.ProductHouseholds.ToList();
        }

        public ProductHousehold GetProductHHById(int id)
        {
            var productHousehold = _context.ProductHouseholds.Find(id);
            if (productHousehold != null)
            {
                return productHousehold;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
