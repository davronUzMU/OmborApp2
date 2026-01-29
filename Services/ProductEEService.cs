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
    public class ProductEEService
    {
        private readonly IProductHouseholdRepository _productHouseholdRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IManagerRepository _managerRepository;

        public ProductEEService(IProductHouseholdRepository productHouseholdRepository, ICategoryRepository categoryRepository, IDepartmentRepository departmentRepository, IManagerRepository managerRepository)
        {
            _productHouseholdRepository = productHouseholdRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
            _managerRepository = managerRepository;
        }
        public List<Models.ProductHousehold> GetProductEEAll() => _productHouseholdRepository.GetProductHHAll();

        public Models.ProductHousehold AddProductEE(Models.ProductHousehold productEE)
        {
            if (productEE == null)
            {
                throw new ArgumentNullException();
            }
            var category = _categoryRepository.GetCategoryAll().FirstOrDefault(x => x.Id == productEE.CategoryId);
            var department = _departmentRepository.GetDepartmentAll().FirstOrDefault(x => x.Id == productEE.DepartmentId);
            var manager = _managerRepository.GetManagerAll().FirstOrDefault(x => x.Id == productEE.ManagerId);
            if (category == null || department == null || manager == null)
            {
                throw new Exception("error");
            }
            var productEE2 = new Models.ProductHousehold
            {
                ProductType = "Xo'jalik  maqsulotlari",
                DepartmentId = productEE.DepartmentId,
                CategoryId = productEE.CategoryId,
                ManagerId = productEE.ManagerId,
                ProductName = productEE.ProductName,
                TotalNumber = productEE.TotalNumber,
                UnicalCode = GenerateCode(),
                locationProduct = productEE.locationProduct,
                ProductDescription = productEE.ProductDescription,
                CreatedAt = DateTime.UtcNow,
            };
            var productEE3 = _productHouseholdRepository.AddProductHH(productEE2);
            return productEE3;
        }

        public void DeleteProductEE(int id) => _productHouseholdRepository.DeleteProductHH(id);

        public ProductHousehold UpdateProductEE(Models.ProductHousehold productEE)
        {
            if (productEE == null)
            {
                throw new ArgumentNullException();
            }
            var category = _categoryRepository.GetCategoryAll().FirstOrDefault(x => x.Id == productEE.CategoryId);
            var department = _departmentRepository.GetDepartmentAll().FirstOrDefault(x => x.Id == productEE.DepartmentId);
            var manager = _managerRepository.GetManagerAll().FirstOrDefault(x => x.Id == productEE.ManagerId);
            if (category == null || department == null || manager == null)
            {
                throw new Exception("error");
            }
            var  productEE2= _productHouseholdRepository.GetProductHHAll().FirstOrDefault(x => x.Id == productEE.Id);
            if (productEE2 == null) {
                throw new Exception("error");
            }
            productEE2.ProductType = "Xo'jalik  maqsulotlari";
            productEE2.DepartmentId = productEE.DepartmentId;
            productEE2.CategoryId = productEE.CategoryId;
            productEE2.ManagerId = productEE.ManagerId;
            productEE2.ProductName = productEE.ProductName;
            productEE2.TotalNumber = productEE.TotalNumber;
            productEE2.UnicalCode = productEE.ProductName+"+@+"+GenerateCode();
            productEE2.locationProduct = productEE.locationProduct;
            productEE2.ProductDescription = productEE.ProductDescription;
            productEE2.CreatedAt = DateTime.UtcNow;

            _productHouseholdRepository.EditProductHH(productEE2);

            return productEE2;
        }
        public ProductHousehold? GetById(int id) => _productHouseholdRepository.GetProductHHAll().FirstOrDefault(x => x.Id == id);

        public List<ProductHousehold> Search(string? productName, string? unicalCode, int? categoryId, int? departmentId)
        {
            var products = _productHouseholdRepository.GetProductHHAll().AsQueryable();
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

        public List<ProductHousehold> SearchHH(string productHH)
        {
            var products = _productHouseholdRepository.GetProductHHAll().AsQueryable();
            if (!string.IsNullOrEmpty(productHH))
            {
                products = products.Where(p => p.ProductName.Contains(productHH, StringComparison.OrdinalIgnoreCase));
            }
            return products.ToList();
        }

        public List<ProductHousehold> SortByDate(bool ascending = true)
        {
            var products = _productHouseholdRepository.GetProductHHAll();
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

            var product = _productHouseholdRepository
                .GetProductHHAll()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
                throw new Exception("Mahsulot topilmadi");

            product.locationProduct = newLocation;

            _productHouseholdRepository.EditProductHH(product);
        }

    }
}
