using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data;
using WinFormsApp1.Repositories;
using WinFormsApp1.Repositories.HictoryRep;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=ombor_guna_baza;Username=postgres;Password=7004");

            var context = new AppDbContext(optionsBuilder.Options);

            IAdminRepository adminRepository = new AdminRepository(context);
            IAdminCodeLogRepository codeLogRepository = new AdminCodeLogRepository(context);
            IManagerCodeRepository managerCodeRepository = new ManagerCodeRepository(context);
            IManagerRepository managerRepository = new ManagerRepository(context);
            ICategoryRepository categoryRepository = new CategoryRepository(context);
            IDepartmentRepository departmentRepository = new DepartmentRepository(context);
            IProductHouseholdRepository productHouseholdRepository = new ProductHouseholdRepository(context);
            IProductRealEstateRepository productRealEstateRepository = new ProductRealEstateRepository(context);
            IProductTexnologyRepository productTexnologyRepository = new ProductTexnologyRepository(context);

            IProductHHHistoryRepository productHHHistoryRepository = new ProductHHHistoryRepository(context);
            IProductREHistoryRepository productREHistoryRepository = new ProductREHistoryRepository(context);
            IProductTexHistoryRepository productTexHistoryRepository = new ProductTexHistoryRepository(context);

            SuperAdminService superAdminService = new SuperAdminService(codeLogRepository);
            AdminService adminService = new AdminService(adminRepository, codeLogRepository, managerCodeRepository);
            ManagerService managerService = new ManagerService(managerRepository, managerCodeRepository);
            CategoryService categoryService = new CategoryService(categoryRepository);
            DepartmentService departmentService = new DepartmentService(departmentRepository);
            ProductEEService productEEService = new ProductEEService(productHouseholdRepository, categoryRepository, departmentRepository, managerRepository);
            ProductREService productREService = new ProductREService(productRealEstateRepository, categoryRepository, departmentRepository, managerRepository);
            ProductTexService productTexService = new ProductTexService(productTexnologyRepository, categoryRepository, departmentRepository, managerRepository);

            ProductREHistoryService productREHistoryService = new ProductREHistoryService(productREHistoryRepository);
            ProductEEHistoryService productEEHistoryService = new ProductEEHistoryService(productHHHistoryRepository);
            ProductTexHistoryService productTexHistoryService = new ProductTexHistoryService(productTexHistoryRepository);


            Application.Run(new Form1(superAdminService, adminService, categoryService, departmentService, managerService, productEEService, productREService, productTexService,productEEHistoryService,productTexHistoryService,productREHistoryService));
        }
    }
}