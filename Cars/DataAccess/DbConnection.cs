using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Cars.Models;
using Cars.ViewModels;
namespace Cars.DataAccess
{
    public class DbConnection : DbContext
    {
        public DbSet<Car> cars{ get; set; }
        public DbSet<Category> categories{ get; set; }
        public DbSet<SubCategory> subCategories{ get; set; }
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;port=5432;Database=Cars;Username=postgres;Password=1998;IncludeErrorDetail=true;"
               
            );
                optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}