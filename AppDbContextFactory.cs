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
            optionsBuilder.UseNpgsql("Host=localhost;Database=ombor_guna_baza;Username=postgres;Password=7004");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}












