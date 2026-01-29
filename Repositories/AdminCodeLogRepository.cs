using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class AdminCodeLogRepository : IAdminCodeLogRepository
    {
        private readonly AppDbContext _context;
        public AdminCodeLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public AdminCodeLog AddAdminCode(AdminCodeLog adminCode)
        {
            _context.AdminCodeLogs.Add(adminCode);
            _context.SaveChanges();
            return adminCode;
        }

        public void DeleteAdminCode(int id)
        {
            var adminCode = _context.AdminCodeLogs.Find(id);
            if (adminCode != null)
            {
                _context.AdminCodeLogs.Remove(adminCode);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Admin code log not found");
            }
        }

        public AdminCodeLog EditAdminCode(AdminCodeLog adminCode)
        {
            _context.AdminCodeLogs.Update(adminCode);
            _context.SaveChanges();
            return adminCode;
        }

        public List<AdminCodeLog> GetAdminCodeAll()
        {
            return _context.AdminCodeLogs.ToList();
        }

        public AdminCodeLog GetAdminCodeById(int id)
        {
            var adminCode = _context.AdminCodeLogs.Find(id);
            if (adminCode != null)
            {
                return adminCode;
            }
            else
            {
                throw new Exception("Admin code log not found");
            }
        }
    }
}
