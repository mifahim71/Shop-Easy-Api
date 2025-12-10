using Microsoft.EntityFrameworkCore;
using ShopEasyApi.Data.Configurations;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => new {u.Email, u.UserName}).IsUnique();

            modelBuilder.Entity<AppUser>()
                .Property(u => u.Role).HasConversion<string>();


            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        }
    }
}
