using aspNet_JWT_Auth.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspNet_JWT_Auth.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.Username);
        }
    }
}
