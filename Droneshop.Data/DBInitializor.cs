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
                Price = 12000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone2 = ctx.Drones.Add(new Drone()
            {
                Id = 2,
                Details = "Super Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer1,
                ProductName = "Matrice 200",
                Price = 22000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone3 = ctx.Drones.Add(new Drone()
            {
                Id = 3,
                Details = "Ultra Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/6/m600pro.jpg",
                Manufacturer = manufacturer2,
                ProductName = "Matrice 600",
                Price = 32000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone4 = ctx.Drones.Add(new Drone()
            {
                Id = 4,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic 2 Pro",
                Price = 11499,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone5 = ctx.Drones.Add(new Drone()
            {
                Id = 5,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Inspire 2 Cinema Pro",
                Price = 151499,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone6 = ctx.Drones.Add(new Drone()
            {
                Id = 6,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer2,
                ProductName = "Inspire 2 Professional",
                Price = 52499,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone7 = ctx.Drones.Add(new Drone()
            {
                Id = 7,
                Details = "All-new DJI Phantom 4 Pro equipped with an uprated camera is equipped with a 1-inch 20-megapixel sensor capable of shooting 4K/60fps video and Burst Mode stills at 14 fps.The adoption of titanium alloy and magnesium alloy construction increases the rigidity of the airframe and reduces weight, making the Phantom 4 Pro similar incredibly light. The Flight Autonomy system adds dual rear vision sensors and infrared sensing systems for a total of 5-direction of obstacle sensing and 4-direction of obstacle avoidance.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_baada688-b74f-4bee-9a2d-9ff2e9782b7d_1.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Phantom 4",
                Price = 12000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone8 = ctx.Drones.Add(new Drone()
            {
                Id = 8,
                Details = "All-new DJI Phantom 4 Pro equipped with an uprated camera is equipped with a 1-inch 20-megapixel sensor capable of shooting 4K/60fps video and Burst Mode stills at 14 fps.The adoption of titanium alloy and magnesium alloy construction increases the rigidity of the airframe and reduces weight, making the Phantom 4 Pro similar incredibly light. The Flight Autonomy system adds dual rear vision sensors and infrared sensing systems for a total of 5-direction of obstacle sensing and 4-direction of obstacle avoidance.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_baada688-b74f-4bee-9a2d-9ff2e9782b7d_1.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Phantom 4",
                Price = 12000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone9 = ctx.Drones.Add(new Drone()
            {
                Id = 9,
                Details = "All-new DJI Phantom 4 Pro equipped with an uprated camera is equipped with a 1-inch 20-megapixel sensor capable of shooting 4K/60fps video and Burst Mode stills at 14 fps.The adoption of titanium alloy and magnesium alloy construction increases the rigidity of the airframe and reduces weight, making the Phantom 4 Pro similar incredibly light. The Flight Autonomy system adds dual rear vision sensors and infrared sensing systems for a total of 5-direction of obstacle sensing and 4-direction of obstacle avoidance.",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/e/medium_baada688-b74f-4bee-9a2d-9ff2e9782b7d_1.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Phantom 4",
                Price = 12000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone10 = ctx.Drones.Add(new Drone()
            {
                Id = 10,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Mavic 2 Pro",
                Price = 11499,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone11 = ctx.Drones.Add(new Drone()
            {
                Id = 11,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                Manufacturer = manufacturer1,
                ProductName = "Inspire 2 Cinema Pro",
                Price = 151499,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone12 = ctx.Drones.Add(new Drone()
            {
                Id = 12,
                Details = "Another drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer2,
                ProductName = "Inspire 2 Professional",
                Price = 52499,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone13 = ctx.Drones.Add(new Drone()
            {
                Id = 13,
                Details = "Super Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/a/matrice-200.png",
                Manufacturer = manufacturer1,
                ProductName = "Matrice 200",
                Price = 22000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            var drone14 = ctx.Drones.Add(new Drone()
            {
                Id = 14,
                Details = "Ultra Nice drone",
                ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/m/6/m600pro.jpg",
                Manufacturer = manufacturer2,
                ProductName = "Matrice 600",
                Price = 32000,
                UserManualURL = "https://dl.djicdn.com/downloads/phantom_4/en/Phantom_4_User_Manual_en_v1.0.pdf"

            }).Entity;

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var admin = ctx.Users.Add(new User()
            {
                Id = 1,
                Username = "AdminAllan",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = true

            }).Entity;
            
            var user2 = ctx.Users.Add(new User()
            {
                Id = 2,
                Username = "User2",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = false

            }).Entity;
            
            var user3 = ctx.Users.Add(new User()
            {
                Id = 3,
                Username = "User3",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = false

            }).Entity;
            
            var user4 = ctx.Users.Add(new User()
            {
                Id = 4,
                Username = "User4",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = false

            }).Entity;

            var customer = ctx.Customers.Add(new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Kongensgade 11",
                PhoneNumber = 12345678,
                Email = "hans.hansen@gmail.com",
                User = user2,
                UserId = user2.Id
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
                FirstName = "Mikkel",
                LastName = "Mikkelsen",
                Address = "Kongensgade 11",
                PhoneNumber = 15748798,
                Email = "mikkel.mikkelsen@gmail.com",
                User = user3,
                UserId = user3.Id
            }).Entity;

            var customer3 = ctx.Customers.Add(new Customer()
            {
                Id = 3,
                FirstName = "Kristian",
                LastName = "Kristiansen",
                Address = "Kristiansgade 112",
                PhoneNumber = 12457612,
                Email = "kristian.kristiansen@gmail.com",
                User = user4,
                UserId = user4.Id
            }).Entity;


            var order1 = ctx.Orders.Add(new Order()
            {
                Id = 1,
                OderDate = DateTime.Now,
                Customer = customer,
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
                OderDate = DateTime.Now,
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