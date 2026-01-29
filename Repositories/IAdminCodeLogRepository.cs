using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IAdminCodeLogRepository
    {
        List<AdminCodeLog> GetAdminCodeAll();
        AdminCodeLog GetAdminCodeById(int id);
        AdminCodeLog AddAdminCode(AdminCodeLog adminCode);
        AdminCodeLog EditAdminCode(AdminCodeLog adminCode);
        void DeleteAdminCode(int id);
    }
}
