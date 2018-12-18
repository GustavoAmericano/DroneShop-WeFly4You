using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Droneshop.Data
{
    public class DroneShopContext : DbContext
    {
        public DroneShopContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drone>().HasOne(d => d.Manufacturer).WithMany(m => m.Drones).OnDelete(DeleteBehavior.SetNull);
            
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<Customer>(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);
                
            
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderLine>().HasKey(ol => new { ol.DroneId, ol.OrderId });
            modelBuilder.Entity<OrderLine>().HasOne(ol => ol.Order).WithMany(o => o.OrderLines).HasForeignKey(ol => ol.OrderId);
            modelBuilder.Entity<OrderLine>().HasOne(ol => ol.Drone).WithMany(d => d.OrderLines).HasForeignKey(ol => ol.DroneId);

        }
    }
}