using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IAdminRepository
    {
        List<Admin> GetAdminAll();
        Admin GetAdminById(int id);
        Admin AddAdmin(Admin admin);
        Admin EditAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}
