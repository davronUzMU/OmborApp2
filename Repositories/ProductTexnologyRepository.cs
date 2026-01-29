using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class ProductTexnologyRepository : IProductTexnologyRepository
    {
        private readonly AppDbContext _context;
        public ProductTexnologyRepository(AppDbContext context)
        {
            _context = context;
        }
        public ProductTexnologiya AddProductTex(ProductTexnologiya productHousehold)
        {
            _context.ProductTexnologiyas.Add(productHousehold);
            _context.SaveChanges();
            return productHousehold;
        }

        public void DeleteProductTex(int id)
        {
            var productTexnologiya = _context.ProductTexnologiyas.Find(id);
            if (productTexnologiya != null)
            {
                _context.ProductTexnologiyas.Remove(productTexnologiya);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductTexnologiya EditProductTex(ProductTexnologiya productHousehold)
        {
            _context.ProductTexnologiyas.Update(productHousehold);
            _context.SaveChanges();
            return productHousehold;
        }

        public List<ProductTexnologiya> GetProductTexAll()
        {
            return _context.ProductTexnologiyas.ToList();
        }

        public ProductTexnologiya GetProductTexById(int id)
        {
            var productTexnologiya = _context.ProductTexnologiyas.Find(id);
            if (productTexnologiya != null)
            {
                return productTexnologiya;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
