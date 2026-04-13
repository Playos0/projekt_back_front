using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
   public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Address);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
    }
}
