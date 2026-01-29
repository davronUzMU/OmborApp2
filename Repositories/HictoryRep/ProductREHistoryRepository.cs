using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repositories.HictoryRep
{
    public class ProductREHistoryRepository:IProductREHistoryRepository
    {
        private readonly AppDbContext _context;
        public ProductREHistoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public ProductRealEstateHistory AddProductREHistory(ProductRealEstateHistory productRealEstateHistory)
        {
            _context.ProductRealEstateHistories.Add(productRealEstateHistory);
            _context.SaveChanges();
            return productRealEstateHistory;
        }
    }
}
