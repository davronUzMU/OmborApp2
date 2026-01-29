using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IManagerCodeRepository
    {
        List<ManagerCode> GetManagerCAll();
        ManagerCode GetManagerCById(int id);
        ManagerCode AddManagerC(ManagerCode admin);
        ManagerCode EditManagerC(ManagerCode admin);
        void DeleteManagerC(int id);
    }
}
