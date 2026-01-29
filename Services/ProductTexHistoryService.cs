using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories.HictoryRep;

namespace WinFormsApp1.Services
{
    public class ProductTexHistoryService
    {
        private readonly IProductTexHistoryRepository _productTexHistoryRepository;
        public ProductTexHistoryService(IProductTexHistoryRepository productTexHistoryRepository)
        {
            _productTexHistoryRepository = productTexHistoryRepository;
        }
        public ProductTexnologyHistory AddProductTexHistory(ProductTexnologyHistory productTexnologyHistory)
        {
            return _productTexHistoryRepository.AddProductTexHistory(productTexnologyHistory);
        }
    }
}
