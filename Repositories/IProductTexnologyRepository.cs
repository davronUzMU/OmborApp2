using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IProductTexnologyRepository
    {
        List<ProductTexnologiya> GetProductTexAll();
        ProductTexnologiya GetProductTexById(int id);
        ProductTexnologiya AddProductTex(ProductTexnologiya productHousehold);
        ProductTexnologiya EditProductTex(ProductTexnologiya productHousehold);
        void DeleteProductTex(int id);
    }
}
