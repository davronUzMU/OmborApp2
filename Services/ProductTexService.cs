using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories;

namespace WinFormsApp1.Services
{
    public class ProductTexService
    {
        private readonly IProductTexnologyRepository _productTexnologyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IManagerRepository _managerRepository;


        public ProductTexService(IProductTexnologyRepository productTexnologyRepository, ICategoryRepository categoryRepository, IDepartmentRepository departmentRepository, IManagerRepository managerRepository)
        {
            _productTexnologyRepository = productTexnologyRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
            _managerRepository = managerRepository;
        }
        public List<Models.ProductTexnologiya> GetProductTexAll() => _productTexnologyRepository.GetProductTexAll();

        public Models.ProductTexnologiya AddProductTex(Models.ProductTexnologiya productTex)
        {
            if (productTex == null)
            {
                throw new ArgumentNullException();
            }
            var category = _categoryRepository.GetCategoryAll().FirstOrDefault(x => x.Id == productTex.CategoryId);
            var department = _departmentRepository.GetDepartmentAll().FirstOrDefault(x => x.Id == productTex.DepartmentId);
            var manager = _managerRepository.GetManagerAll().FirstOrDefault(x => x.Id == productTex.ManagerId);
            if (category == null || department == null || manager == null)
            {
                throw new Exception("error");
            }
            var productTex2 = new Models.ProductTexnologiya
            {
                ProductType = "Texnologiya",
                DepartmentId = productTex.DepartmentId,
                CategoryId = productTex.CategoryId,
                ManagerId = productTex.ManagerId,
                ProductName = productTex.ProductName,
                TotalNumber = productTex.TotalNumber,
                UnicalCode = productTex.ProductName+"+@+"+GenerateCode(),
                locationProduct = productTex.locationProduct,
                ProductDescription = productTex.ProductDescription,
                CreatedAt = DateTime.UtcNow,
            };
            var productTex3 = _productTexnologyRepository.AddProductTex(productTex2);
            return productTex3;
        }
        public void DeleteProductTex(int id) => _productTexnologyRepository.DeleteProductTex(id);

        public ProductTexnologiya UpdateProductTex(Models.ProductTexnologiya productTex)
        {
            if (productTex == null)
            {
                throw new ArgumentNullException();
            }
            var category = _categoryRepository.GetCategoryAll().FirstOrDefault(x => x.Id == productTex.CategoryId);
            var department = _departmentRepository.GetDepartmentAll().FirstOrDefault(x => x.Id == productTex.DepartmentId);
            var manager = _managerRepository.GetManagerAll().FirstOrDefault(x => x.Id == productTex.ManagerId);
            if (category == null || department == null || manager == null)
            {
                throw new Exception("error");
            }
            var productTex2 =_productTexnologyRepository.GetProductTexById(productTex.Id);
            if (productTex2 == null)
            {
                throw new Exception("error");
            }
            productTex2.ProductType = "Texnologiya";
            productTex2.DepartmentId = productTex.DepartmentId;
            productTex2.CategoryId = productTex.CategoryId;
            productTex2.ManagerId = productTex.ManagerId;
            productTex2.ProductName = productTex.ProductName;
            productTex2.TotalNumber = productTex.TotalNumber;
            productTex2.UnicalCode = productTex.ProductName+"<-@->"+GenerateCode();
            productTex2.locationProduct = productTex.locationProduct;
            productTex2.ProductDescription = productTex.ProductDescription;
            productTex2.CreatedAt=DateTime.UtcNow;

            return _productTexnologyRepository.EditProductTex(productTex2);
            
        }

        public ProductTexnologiya GetProductTexById(int id)
        {
            var productTex = _productTexnologyRepository.GetProductTexById(id);
            if (productTex == null)
            {
                throw new Exception("error");
            }
            return productTex;
        }
        public List<ProductTexnologiya> Search(string? productName, string? unicalCode, int? categoryId, int? departmentId)
        {
            var products = _productTexnologyRepository.GetProductTexAll().AsQueryable();
            if (!string.IsNullOrEmpty(productName))
            {
                products = products.Where(p => p.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(unicalCode))
            {
                products = products.Where(p => p.UnicalCode.Contains(unicalCode, StringComparison.OrdinalIgnoreCase));
            }
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }
            if (departmentId.HasValue)
            {
                products = products.Where(p => p.DepartmentId == departmentId.Value);
            }
            return products.ToList();
        }

        public List<ProductTexnologiya> SearchRE(string productR)
        {
            var products = _productTexnologyRepository.GetProductTexAll().AsQueryable();
            if (!string.IsNullOrEmpty(productR))
            {
                products = products.Where(p => p.ProductName.Contains(productR, StringComparison.OrdinalIgnoreCase));
            }
            return products.ToList();
        }

        public List<ProductTexnologiya> SortByDate(bool ascending = true)
        {
            var products = _productTexnologyRepository.GetProductTexAll();
            return ascending
                ? products.OrderBy(p => p.CreatedAt).ToList()
                : products.OrderByDescending(p => p.CreatedAt).ToList();
        }


        public static string GenerateCode()
        {
            return GeneratePassword(24);
        }
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                             "abcdefghijklmnopqrstuvwxyz" +
                             "0123456789" +
                             "!@#$%^&*()-_=+[]{}|;:,.<>?";
        public static string GeneratePassword(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

            var charArray = chars.ToCharArray();
            int k = charArray.Length; // belgilarning soni (masalan 88)
            var result = new char[length];

            // 256 ning qaysi qismi to'liq bo'linadi:
            int maxExclusive = 256 - (256 % k); // rejection sampling uchun limit

            byte[] buffer = new byte[128]; // har safar to'ldiriladigan buffer (o'zgartirish mumkin)
            int filled = 0;
            int pos = 0;

            using (var rng = RandomNumberGenerator.Create())
            {
                while (pos < length)
                {
                    // buffer to'ldirish
                    rng.GetBytes(buffer);
                    for (int i = 0; i < buffer.Length && pos < length; i++)
                    {
                        byte b = buffer[i];
                        // rejection sampling: faqat b < maxExclusive qabul qilamiz
                        if (b < maxExclusive)
                        {
                            int idx = b % k;
                            result[pos++] = charArray[idx];
                        }
                        // aks holda rad etiladi va keyingi baytga o'tiladi
                    }
                }
            }

            return new string(result);
        }

        public void UpdateLocation(int id, string newLocation)
        {
            if (string.IsNullOrWhiteSpace(newLocation))
                throw new ArgumentException("Location bo‘sh bo‘lishi mumkin emas");

            var product = _productTexnologyRepository
                .GetProductTexAll()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
                throw new Exception("Mahsulot topilmadi");

            product.locationProduct = newLocation;

            _productTexnologyRepository.EditProductTex(product);
        }

    }
}







































