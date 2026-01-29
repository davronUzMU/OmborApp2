using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IProductHouseholdRepository
    {
        List<ProductHousehold> GetProductHHAll();
        ProductHousehold GetProductHHById(int id);
        ProductHousehold AddProductHH(ProductHousehold productHousehold);
        ProductHousehold EditProductHH(ProductHousehold productHousehold);
        void DeleteProductHH(int id);
    }
}
