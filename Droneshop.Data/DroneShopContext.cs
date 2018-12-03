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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drone>().HasOne(d => d.Manufacturer).WithMany(m => m.Drones).OnDelete(DeleteBehavior.SetNull);
        }
    }
}