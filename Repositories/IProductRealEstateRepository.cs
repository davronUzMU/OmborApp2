using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp1.Repositories
{
    public interface IProductRealEstateRepository
    {
        List<ProductRealEstate> GetProductREAll();
        ProductRealEstate GetProductREById(int id);
        ProductRealEstate AddProductRE(ProductRealEstate productHousehold);
        ProductRealEstate EditProductRE(ProductRealEstate productHousehold);
        void DeleteProductRE(int id);
    }
}
