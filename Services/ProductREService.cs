using WinFormsApp1.Models;
using WinFormsApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class ProductREService
    {
        private readonly IProductRealEstateRepository _productRealEstateRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IManagerRepository _managerRepository;
        public ProductREService(IProductRealEstateRepository productRealEstateRepository, ICategoryRepository categoryRepository, IDepartmentRepository departmentRepository, IManagerRepository managerRepository)
        {
            _productRealEstateRepository = productRealEstateRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
            _managerRepository = managerRepository;
        }
        public List<Models.ProductRealEstate> GetProductREAll() => _productRealEstateRepository.GetProductREAll();
        public Models.ProductRealEstate AddProductRE(Models.ProductRealEstate productRE)
        {
            if (productRE == null)
            {
                throw new ArgumentNullException();
            }
            var category = _categoryRepository.GetCategoryAll().FirstOrDefault(x => x.Id == productRE.CategoryId);
            var department = _departmentRepository.GetDepartmentAll().FirstOrDefault(x => x.Id == productRE.DepartmentId);
            var manager = _managerRepository.GetManagerAll().FirstOrDefault(x => x.Id == productRE.ManagerId);
            if (category == null || department == null || manager == null)
            {
                throw new Exception("error");
            }
            var productRE2 = new Models.ProductRealEstate
            {
                ProductType = "Ko'chmas mulk",
                DepartmentId = productRE.DepartmentId,
                CategoryId = productRE.CategoryId,
                ManagerId = productRE.ManagerId,
                productLocation = productRE.productLocation,
                ProductDescription = productRE.ProductDescription,
                TotalNumber = productRE.TotalNumber,
                CreatedAt = DateTime.UtcNow,
            };
            var productRE3 = _productRealEstateRepository.AddProductRE(productRE2);
            return productRE3;
        }
        public void DeleteProductRE(int id) => _productRealEstateRepository.DeleteProductRE(id);

        public ProductRealEstate UpdateProductRE(Models.ProductRealEstate productRE)
        {
            if (productRE == null)
            {
                throw new ArgumentNullException();
            }
            var category = _categoryRepository.GetCategoryAll().FirstOrDefault(x => x.Id == productRE.CategoryId);
            var department = _departmentRepository.GetDepartmentAll().FirstOrDefault(x => x.Id == productRE.DepartmentId);
            var manager = _managerRepository.GetManagerAll().FirstOrDefault(x => x.Id == productRE.ManagerId);
            if (category == null || department == null || manager == null)
            {
                throw new Exception("error");
            }
            var productRE2 =_productRealEstateRepository.GetProductREAll().FirstOrDefault(x => x.Id == productRE.Id);
            if (productRE2 == null)
            {
                throw new Exception("error");
            }
            productRE2.DepartmentId = productRE.DepartmentId;
            productRE2.CategoryId = productRE.CategoryId;
            productRE2.ManagerId = productRE.ManagerId;
            productRE2.productLocation = productRE.productLocation;
            productRE2.ProductDescription = productRE.ProductDescription;
            productRE2.TotalNumber = productRE.TotalNumber;
            productRE2.CreatedAt = DateTime.UtcNow;

            return _productRealEstateRepository.EditProductRE(productRE2);
            //return productRE2;
        }

        public ProductRealEstate GetProductREById(int id)
        {
            var productRE = _productRealEstateRepository.GetProductREAll().FirstOrDefault(x => x.Id == id);
            if (productRE == null)
            {
                throw new Exception("error");
            }
            return productRE;
        }
        public List<ProductRealEstate> Search(string productLocation)
        {
           var products = _productRealEstateRepository.GetProductREAll().AsQueryable();
            if (!string.IsNullOrEmpty(productLocation))
            {
                products = products.Where(p => p.productLocation.Contains(productLocation, StringComparison.OrdinalIgnoreCase));
            }
            return products.ToList();
        }
        public List<ProductRealEstate> SortByDate(bool ascending = true)
        {
            var products = _productRealEstateRepository.GetProductREAll();
            return ascending
                ? products.OrderBy(p => p.CreatedAt).ToList()
                : products.OrderByDescending(p => p.CreatedAt).ToList();
        }


        public void UpdateLocation(int id, string newLocation)
        {
            if (string.IsNullOrWhiteSpace(newLocation))
                throw new ArgumentException("Location bo‘sh bo‘lishi mumkin emas");

            var product = _productRealEstateRepository
                .GetProductREAll()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
                throw new Exception("Mahsulot topilmadi");

            product.productLocation = newLocation;

            _productRealEstateRepository.EditProductRE(product);
        }

    }
}
