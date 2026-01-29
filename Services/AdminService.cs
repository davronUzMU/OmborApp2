using WinFormsApp1.Models;
using WinFormsApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAdminCodeLogRepository _codeLogRepository;
        private readonly IManagerCodeRepository _managerCodeRepository;

        public AdminService(IAdminRepository adminRepository, IAdminCodeLogRepository codeLogRepository, IManagerCodeRepository managerCodeRepository)
        {
            _adminRepository = adminRepository;
            _codeLogRepository = codeLogRepository;
            _managerCodeRepository = managerCodeRepository;
        }

        //public AdminService(IAdminRepository adminRepository, IAdminCodeLogRepository codeLogRepository)
        //{
        //    _adminRepository = adminRepository;
        //    _codeLogRepository = codeLogRepository;
        //}
        public Admin? LoginWithCode(string fullname, string code)
        {
            // Avval mavjud adminni tekshiramiz
            var existingAdmin = _adminRepository
                .GetAdminAll()
                .FirstOrDefault(x => x.FullName == fullname && x.Code == code);

            if (existingAdmin != null)
            {
                return existingAdmin;
            }

            // Agar mavjud bo'lmasa, codeLog ni tekshiramiz
            var codeLog = _codeLogRepository
                .GetAdminCodeAll()
                .FirstOrDefault(x => x.GeneratedCode == code && !x.Used);

            if (codeLog == null)
                return null;

            // Yangi admin yaratamiz
            var newAdmin = new Admin
            {
                FullName = fullname,
                Code = code,
                District = codeLog.District,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            // Admin qo‘shamiz
            _adminRepository.AddAdmin(newAdmin);

            // Kodni ishlatilgan deb belgilaymiz
            codeLog.Used = true;
            codeLog.UsedAt = DateTime.UtcNow;
            _codeLogRepository.EditAdminCode(codeLog);

            return newAdmin;
        }

        public ManagerCode ManagerCode()
        {
            // manager uchun kod generatsiya qilish
            var Code = Guid.NewGuid().ToString("N")[..12].ToUpper();
            var managerCode = new ManagerCode
            {
                TypeManager = "Manager",
                GeneratedBy = "Admin",
                Used = false,
                Code = Code,
                CreatedAt = DateTime.UtcNow
            };
            _managerCodeRepository.AddManagerC(managerCode);
            return managerCode;
        }


        public List<Admin> GetAllAdmins() => _adminRepository.GetAdminAll();

        public void DeleteAdmin(int id) => _adminRepository.DeleteAdmin(id);
    }
}
