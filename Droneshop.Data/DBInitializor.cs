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
                ProductName = "Phantom 4",
                Price = 12000
            }).Entity;
            
            var drone2 = ctx.Drones.Add(new Drone()
            {
                Id = 2,
                Details = "Super Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer1,
                ProductName = "Matrice 200",
                Price = 22000
            }).Entity;
            
            var drone3 = ctx.Drones.Add(new Drone()
            {
                Id = 3,
                Details = "Ultra Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/6/m600pro.jpg",
                Manufacturer = manufacturer2,
                ProductName = "Matrice 600",
                Price = 32000
            }).Entity;
            
            var drone4 = ctx.Drones.Add(new Drone()
            {
                Id = 4,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic 2 Pro",
                Price = 11499
            }).Entity;
            
            var drone5 = ctx.Drones.Add(new Drone()
            {
                Id = 5,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Inspire 2 Cinema Pro",
                Price = 151499
            }).Entity;
            
            var drone6 = ctx.Drones.Add(new Drone()
            {
                Id = 6,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer2,
                ProductName = "Inspire 2 Professional",
                Price = 52499
            }).Entity;

            ctx.SaveChanges();
        }
    }
}