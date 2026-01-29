using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories.HictoryRep;

namespace WinFormsApp1.Services
{
    public class ProductEEHistoryService
    {
        private readonly IProductHHHistoryRepository _productHHHistoryRepository;

        public ProductEEHistoryService(IProductHHHistoryRepository productHHHistoryRepository)
        {
            _productHHHistoryRepository = productHHHistoryRepository;
        }
        public ProductHouseHoldHistory AddProductHistory(ProductHouseHoldHistory productHouseHoldHistory)
        {
            return _productHHHistoryRepository.AddProductHouseHoldHistory(productHouseHoldHistory);
        }
    }
}
