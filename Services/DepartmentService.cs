using WinFormsApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public List<Models.Department> GetDepartmentAll() => _departmentRepository.GetDepartmentAll();

        public Models.Department AddDepartment(Models.Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException();
            }
            var department2 = new Models.Department
            {
                DepartmentName = department.DepartmentName,
                CreatedAt = DateTime.UtcNow,
            };
            var department3 = _departmentRepository.AddDepartment(department2);
            return department3;
        }
        public void DeleteDepartment(int id) => _departmentRepository.DeleteDepartment(id);

        public void UpdateDepartment(Models.Department department) {
            if (department == null)
            {
                throw new ArgumentNullException();
            }
            var department2 =_departmentRepository.GetDepartmentById(department.Id);
            department2.DepartmentName = department.DepartmentName;
            department2.CreatedAt = DateTime.UtcNow;

            _departmentRepository.EditDepartment(department2);
        }
    }
}
