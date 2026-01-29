using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IManagerRepository
    {
        List<Manager> GetManagerAll();
        Manager GetManagerById(int id);
        Manager AddManager(Manager admin);
        Manager EditManager(Manager admin);
        void DeleteManager(int id);
    }
}
