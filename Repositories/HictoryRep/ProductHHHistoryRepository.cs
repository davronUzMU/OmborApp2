using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repositories.HictoryRep
{
    public class ProductHHHistoryRepository : IProductHHHistoryRepository
    {
        private readonly AppDbContext _context;

        public ProductHHHistoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public ProductHouseHoldHistory AddProductHouseHoldHistory(ProductHouseHoldHistory productHouseHoldHistory)
        {
            _context.ProductHouseholdHistories.Add(productHouseHoldHistory);
            _context.SaveChanges();
            return productHouseHoldHistory;
        }
    }
}
