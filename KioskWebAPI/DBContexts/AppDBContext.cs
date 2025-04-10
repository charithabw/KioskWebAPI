using Kiosk.WebAPI.Models;
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
        public DbSet<HomeScreenGetModel> HomeScreenGetModel { get; set; }
        public DbSet<CategoryGetModel> CategoryGetModel { get; set; }
        public DbSet<ProductNameGetModel> ProductNameGetModel { get; set; }
        public DbSet<ProductDetailGetModel> ProductDetailGetModel { get; set; }
        public DbSet<ProductImageGetModel> ProductImageGetModel { get; set; }
        public DbSet<PermissionGetModel> PermissionGetModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mark UserLoginResultModel as a keyless entity
            modelBuilder.Entity<UserLoginResultModel>().HasNoKey();
            modelBuilder.Entity<HomeScreenGetModel>().HasNoKey();
            modelBuilder.Entity<CategoryGetModel>().HasNoKey();
            modelBuilder.Entity<ProductNameGetModel>().HasNoKey();
            modelBuilder.Entity<ProductDetailGetModel>().HasNoKey();
            modelBuilder.Entity<ProductImageGetModel>().HasNoKey();
            modelBuilder.Entity<PermissionGetModel>().HasNoKey();

            // Other entity configurations (if any)
        }
    }
}
