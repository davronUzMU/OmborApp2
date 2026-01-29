using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public Admin AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public void DeleteAdmin(int id)
        {
           var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
            else { 
                throw new Exception("Admin not found");
            }
        }

        public Admin EditAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;
        }

        public List<Admin> GetAdminAll()
        {
            return _context.Admins.ToList();
        }

        public Admin GetAdminById(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                return admin;
            }
            else
            {
                throw new Exception("Admin not found");
            }
        }
    }
}
