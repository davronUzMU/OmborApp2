using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class ManagerCodeRepository : IManagerCodeRepository
    {
        private readonly AppDbContext _context;
        public ManagerCodeRepository(AppDbContext context)
        {
            _context = context;
        }
        public ManagerCode AddManagerC(ManagerCode admin)
        {
            _context.ManagerCode.Add(admin);
            _context.SaveChanges();
            return admin;
            
        }

        public void DeleteManagerC(int id)
        {
            var managerCode = _context.ManagerCode.Find(id);
            if (managerCode != null)
            {
                _context.ManagerCode.Remove(managerCode);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Manager not found");
            }
           
        }

        public ManagerCode EditManagerC(ManagerCode admin)
        {
            _context.ManagerCode.Update(admin);
            _context.SaveChanges();
            return admin;
           
        }

        public List<ManagerCode> GetManagerCAll()
        {
            return _context.ManagerCode.ToList();
           
        }

        public ManagerCode GetManagerCById(int id)
        {
            var managerCode = _context.ManagerCode.Find(id);
            if (managerCode != null)
            {
                return managerCode;
            }
            else
            {
                throw new Exception("Manager not found");
            }
        }
    }
}
