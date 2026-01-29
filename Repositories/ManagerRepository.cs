using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly AppDbContext _context;
        public ManagerRepository(AppDbContext context)
        {
            _context = context;
        }
        public Manager AddManager(Manager admin)
        {
            _context.Managers.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public void DeleteManager(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Manager not found");
            }
        }

        public Manager EditManager(Manager admin)
        {
            _context.Managers.Update(admin);
            _context.SaveChanges();
            return admin;
        }

        public List<Manager> GetManagerAll()
        {
            return _context.Managers.ToList();
        }

        public Manager GetManagerById(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager != null)
            {
                return manager;
            }
            else
            {
                throw new Exception("Manager not found");
            }
        }
    }
}
