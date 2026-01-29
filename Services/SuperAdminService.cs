using WinFormsApp1.Models;
using WinFormsApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class SuperAdminService
    {
        private readonly IAdminCodeLogRepository _adminCodeLogRepository;
        public SuperAdminService(IAdminCodeLogRepository adminCodeLogRepository)
        {
            _adminCodeLogRepository = adminCodeLogRepository;
        }
        public bool Login(string username, string code)
        {
            var expectedUsername = "superAdmin";
            var expectedCode = "DoPBN4k82Pk9M4pQGmyXU81SjctLQnwz";

            return username == expectedUsername
                && code == expectedCode;
        }

        public AdminCodeLog GenerateCode(string district)
        {
            var generatedCode = Guid.NewGuid().ToString("N")[..16].ToUpper();

            var codeLog = new AdminCodeLog
            {
                GeneratedCode = generatedCode,
                District = district,
                CreatedAt = DateTime.UtcNow
            };

            _adminCodeLogRepository.AddAdminCode(codeLog);
            return codeLog;
        }

        public List<AdminCodeLog> GetAllGeneratedCodes() => _adminCodeLogRepository.GetAdminCodeAll();
    }
}
