using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WinFormsApp1.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMBORXONA
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=192.168.1.100;Database=ombor_guna_baza;Username=postgres;Password=123456a");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}












