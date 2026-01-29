using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repositories.HictoryRep
{
    public interface IProductTexHistoryRepository
    {
        ProductTexnologyHistory AddProductTexHistory(ProductTexnologyHistory productTexnologyHistory);
    }
}
