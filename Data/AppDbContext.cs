using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WinFormsApp1.Models.Admin> Admins { get; set; }
        public DbSet<WinFormsApp1.Models.AdminCodeLog> AdminCodeLogs { get; set; }
        public DbSet<WinFormsApp1.Models.Department> Departments { get; set; }
        public DbSet<WinFormsApp1.Models.Category> Categories { get; set; }
        public DbSet<WinFormsApp1.Models.ProductTexnologiya> ProductTexnologiyas { get; set; }
        public DbSet<WinFormsApp1.Models.ProductTexnologyHistory> ProductTexnologyHistories { get; set; }
        public DbSet<WinFormsApp1.Models.ProductHousehold> ProductHouseholds { get; set; }
        public DbSet<WinFormsApp1.Models.ProductHouseHoldHistory> ProductHouseholdHistories { get; set; }
        public DbSet<WinFormsApp1.Models.ProductRealEstate> ProductRealEstates { get; set; }
        public DbSet<WinFormsApp1.Models.ProductRealEstateHistory> ProductRealEstateHistories { get; set; }
        public DbSet<WinFormsApp1.Models.Manager> Managers { get; set; }
        public DbSet<WinFormsApp1.Models.ManagerCode> ManagerCode { get; set; }

    }
}
