using Droneshop.Core.Entity;
using Droneshop.Core.Helpers;
using System;
using System.Collections.Generic;

namespace Droneshop.Data
{
    public class DBInitializor : IDBInitializor
    {
        private readonly IAuthenticationHelper _authenticationHelper;

        public DBInitializor(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }

        public void SeedDB(DroneShopContext ctx)
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
                Details = "All-new DJI Phantom 4 Pro equipped with an uprated camera is equipped with a 1-inch 20-megapixel sensor capable of shooting 4K/60fps video and Burst Mode stills at 14 fps.The adoption of titanium alloy and magnesium alloy construction increases the rigidity of the airframe and reduces weight, making the Phantom 4 Pro similar incredibly light. The Flight Autonomy system adds dual rear vision sensors and infrared sensing systems for a total of 5-direction of obstacle sensing and 4-direction of obstacle avoidance.",
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

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var user = ctx.Users.Add(new User()
            {
                Id = 1,
                Username = "AdminAllan",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = true
                
            }).Entity;


            var customer1 = ctx.Customers.Add(new Customer()
            {
                Id = 1,
                FirstName = "cust1",
                LastName = "cust1",
                Address = "testVej1",
                Email = "test@test.test",
                PhoneNumber = 12345678
            }).Entity;

            var customer2 = ctx.Customers.Add(new Customer()
            {
                Id = 2,
                FirstName = "cust2",
                LastName = "cust2",
                Address = "testVej2",
                Email = "test@test.test",
                PhoneNumber = 12345678
            }).Entity;


            var order1 = ctx.Orders.Add(new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = customer1,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        DroneId = 1,
                        Qty = 5,
                        BoughtPrice = 500
                    }
                }      
            }).Entity;


            var order2 = ctx.Orders.Add(new Order()
            {
                Id = 2,
                OrderDate = DateTime.Now,
                Customer = customer2,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        DroneId = 2,
                        Qty = 5,
                        BoughtPrice = 500
                    }
                }
            }).Entity;


/*
            var orderLine1 = ctx.OrderLines.Add(new OrderLine()
            {
                DroneId = 1,
                Drone = drone1,
                OrderId = 1,
                Order = order1,
                Qty = 2,
                BoughtPrice = 2000
                
            }).Entity;*/

            ctx.SaveChanges();
        }

    }
}