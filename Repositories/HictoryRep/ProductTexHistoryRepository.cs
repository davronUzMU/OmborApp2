using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repositories.HictoryRep
{
    public class ProductTexHistoryRepository: IProductTexHistoryRepository
    {
        private readonly AppDbContext _context;
        public ProductTexHistoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public ProductTexnologyHistory AddProductTexHistory(ProductTexnologyHistory productTexnologyHistory)
        {
            _context.ProductTexnologyHistories.Add(productTexnologyHistory);
            _context.SaveChanges();
            return productTexnologyHistory;
        }
    }
}
