using WinFormsApp1.Data;
using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Department not found");
            }
        }

        public Department EditDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return department;
        }

        public List<Department> GetDepartmentAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                return department;
            }
            else
            {
                throw new Exception("Department not found");
            }
        }
    }
}
