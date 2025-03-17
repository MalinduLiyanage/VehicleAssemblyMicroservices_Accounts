using AccountsService.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AccountsService.Attributes;

namespace AccountsService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database migration failed: {ex.Message}");
            }
        }

        public DbSet<VehicleModel> vehicles { get; set; }
        public DbSet<WorkerModel> workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GlobalAttributes.mySQLConfig.connectionString, ServerVersion.AutoDetect(GlobalAttributes.mySQLConfig.connectionString));
            }
        }
    }
}
