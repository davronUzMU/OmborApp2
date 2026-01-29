using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories.HictoryRep;

namespace WinFormsApp1.Services
{
    public class ProductREHistoryService
    {
        private readonly IProductREHistoryRepository _productREHistoryRepository;
        public ProductREHistoryService(IProductREHistoryRepository productREHistoryRepository)
        {
            _productREHistoryRepository = productREHistoryRepository;
        }
        public ProductRealEstateHistory AddProductREHistory(ProductRealEstateHistory productRealEstateHistory)
        {
            return _productREHistoryRepository.AddProductREHistory(productRealEstateHistory);
        }
    }
}
