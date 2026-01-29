using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class ProductRealEstateRepository : IProductRealEstateRepository
    {
        private readonly AppDbContext _context;
        public ProductRealEstateRepository(AppDbContext context)
        {
            _context = context;
        }
        public ProductRealEstate AddProductRE(ProductRealEstate productHousehold)
        {
            _context.ProductRealEstates.Add(productHousehold);
            _context.SaveChanges();
            return productHousehold;
        }

        public void DeleteProductRE(int id)
        {
            var productRealEstate = _context.ProductRealEstates.Find(id);
            if (productRealEstate != null)
            {
                _context.ProductRealEstates.Remove(productRealEstate);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductRealEstate EditProductRE(ProductRealEstate productHousehold)
        {
            _context.ProductRealEstates.Update(productHousehold);
            _context.SaveChanges();
            return productHousehold;
        }

        public List<ProductRealEstate> GetProductREAll()
        {
            return _context.ProductRealEstates.ToList();
        }

        public ProductRealEstate GetProductREById(int id)
        {
            var productRealEstate = _context.ProductRealEstates.Find(id);
            if (productRealEstate != null)
            {
                return productRealEstate;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
