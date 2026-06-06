using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
   public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<FishingSpot> FishingSpots { get; set; }
        public DbSet<FishingPass> FishingPasses { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address);


            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);


            //strefa do pass i sub
            modelBuilder.Entity<FishingPass>()
                .HasOne(fp => fp.FishingSpot)
                .WithMany()
                .HasForeignKey(fp => fp.FishingSpotId);

            modelBuilder.Entity<FishingPass>()
                .HasOne(fp => fp.User)
                .WithMany()
                .HasForeignKey(fp => fp.UserId);

            modelBuilder.Entity<SubscriptionPlan>()
                .HasOne(sp => sp.FishingSpot)
                .WithMany()
                .HasForeignKey(sp => sp.FishingSpotId);

            modelBuilder.Entity<UserSubscription>()
                .HasOne(us => us.SubscriptionPlan)
                .WithMany()
                .HasForeignKey(us => us.SubscriptionPlanId);

            modelBuilder.Entity<UserSubscription>()
                .HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<FishingSpot>()
                .Property(f => f.DayPassPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SubscriptionPlan>()
                .Property(sp => sp.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<FishingPass>()
                .Property(fp => fp.Price)
                .HasPrecision(18, 2);

            //do łowsisk długość i szerokość
            modelBuilder.Entity<FishingSpot>()
                .Property(f => f.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<FishingSpot>()
                .Property(f => f.Longitude)
                .HasPrecision(9, 6);

            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        } 
    }
}
