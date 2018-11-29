using Droneshop.Core.Entity;

namespace Droneshop.Data
{
    public class DBInitializor
    {
        public static void SeedDB(DroneShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var manufacturer1 = ctx.Manufacturers.Add(new Manufacturer()
            {
                Id = 1,
                Name = "DJI"
            }).Entity;
            
            var manufacturer2 = ctx.Manufacturers.Add(new Manufacturer()
            {
                Id = 2,
                Name = "ADB"
            }).Entity;
            
            var drone1 = ctx.Drones.Add(new Drone()
            {
                Id = 1,
                Details = "Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_baada688-b74f-4bee-9a2d-9ff2e9782b7d_1.jpg",
                Manufacturer = manufacturer1,
                Model = "Phantom 4",
                Price = 12000
            }).Entity;
            
            var drone2 = ctx.Drones.Add(new Drone()
            {
                Id = 2,
                Details = "Super Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer1,
                Model = "Matrice 200",
                Price = 22000
            }).Entity;
            
            var drone3 = ctx.Drones.Add(new Drone()
            {
                Id = 3,
                Details = "Ultra Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/6/m600pro.jpg",
                Manufacturer = manufacturer2,
                Model = "Matrice 600",
                Price = 32000
            }).Entity;

            ctx.SaveChanges();
        }
    }
}