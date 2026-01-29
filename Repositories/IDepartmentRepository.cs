using WinFormsApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartmentAll();
        Department GetDepartmentById(int id);
        Department AddDepartment(Department department);
        Department EditDepartment(Department department);
        void DeleteDepartment(int id);
    }
}
