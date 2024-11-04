using KioskWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KioskWebAPI.DBContexts
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<UserLoginResultModel> UserLoginModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mark UserLoginResultModel as a keyless entity
            modelBuilder.Entity<UserLoginResultModel>().HasNoKey();

            // Other entity configurations (if any)
        }
    }
}
