using WinFormsApp1.Models;
using WinFormsApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class ManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IManagerCodeRepository _managerCodeRepository;
        public ManagerService(IManagerRepository managerRepository, IManagerCodeRepository managerCodeRepository)
        {
            _managerRepository = managerRepository;
            _managerCodeRepository = managerCodeRepository;
        }
        
        public Manager ? Login(string fullname, string code)
        {
            var existingManager = _managerRepository
                .GetManagerAll()
                .FirstOrDefault(x => x.FullName == fullname && x.ManagerCode == code);
            if (existingManager != null)
            {
                return existingManager;
            }
            var managerCode = _managerCodeRepository
                .GetManagerCAll()
                .FirstOrDefault(x => x.Code == code && !x.Used);
            if ((managerCode==null))
            {
                return null;
            }
            var manager = new Manager
            {
                FullName = fullname,
                ManagerCode = code,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _managerRepository.AddManager(manager);
            managerCode.Used = true;
            managerCode.CreatedAt = DateTime.UtcNow;
            _managerCodeRepository.EditManagerC(managerCode);

            return manager;
        }

        public Manager AddManager(Manager manager) { 
            if(manager == null)
            {
                throw new ArgumentNullException();
            }
            List<ManagerCode> managerCodes =_managerCodeRepository.GetManagerCAll();
            foreach (ManagerCode code in managerCodes) {
                if (!code.Code.Equals(manager.ManagerCode))
                {
                    throw new Exception("error manager");
                }
            }
            var manager2 = new Manager { 
                FullName = manager.FullName,
                ManagerCode = manager.ManagerCode,
            };
            var manager3=_managerRepository.AddManager(manager2);
            return manager3;
        }

        public List<ManagerCode> GetManagerCAll() => _managerCodeRepository.GetManagerCAll();

        public List<Manager> GetManagerAll()=>_managerRepository.GetManagerAll();

        public void DeleteManagerCode(int id) => _managerCodeRepository.DeleteManagerC(id);
        public void DeleteManager(int id)=>_managerRepository.DeleteManager(id);
    }
}
