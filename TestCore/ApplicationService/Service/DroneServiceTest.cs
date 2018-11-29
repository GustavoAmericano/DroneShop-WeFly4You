using Droneshop.Core.ApplicationService;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestCore
{
    public class DroneServiceTest
    {

        [Fact]
        public void ReadAllDronesEnsureRepositoryIsCalled()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);

            var isCalled = false;
            var filter = new Filter();

            droneRepo.Setup(x => x.GetAllDrones(filter)).Callback(() => isCalled = true).Returns(new List<Drone>()
            {
                 new Drone()
            {
                Id = 1,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                Model = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"

            }

            });

            service.GetAllDrones(filter);
            Assert.True(isCalled);

        }



        [Fact]
        public void CreateDroneEnsureRepositoryIsCalled()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);

            var isCalled = false;

            var drone = new Drone()
            {
                Id = 1,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                Model = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"

            };

            droneRepo.Setup(x => x.Create(drone)).Callback(() => isCalled = true).Returns(drone);

            service.Create(drone);

            Assert.True(isCalled);

        }

        //Testing whether or not an exception will be thrown if manufacturer = null
        [Fact]
        public void CreateDroneNoManufacturerException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);
            Drone drone = new Drone()
            {
                Id = 1,
                /*Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },*/
                Model = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"


            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("Manufacturer cannot be null or empty", e.Message);
        }


        //Testing whether or not an exception will be thrown if model = null
        [Fact]
        public void CreateDroneNoModelException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);
            Drone drone = new Drone()
            {
                Id = 1,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                //Model = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"


            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("Model cannot be null or empty", e.Message);
        }



        //Testing whether or not an exception will be thrown if price = null
        [Fact]
        public void CreateDroneNoPriceException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);
            Drone drone = new Drone()
            {
                Id = 1,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                Model = "B15",
                //Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"


            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("Price cannot be null or empty", e.Message);
        }



        //Testing whether or not an exception will be thrown if details = null
        [Fact]
        public void CreateDroneNoDetailsException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);
            Drone drone = new Drone()
            {
                Id = 1,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                Model = "B15",
                Price = 500,
                //Details = "Handsome",
                ImageURL = "www.imgUrl.com"


            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("Details cannot be null or empty", e.Message);
        }


        //Testing whether or not an exception will be thrown if ImageUrl = null
        [Fact]
        public void CreateDroneNoImageURLException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);
            Drone drone = new Drone()
            {
                Id = 1,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                Model = "B15",
                Price = 500,
                Details = "Handsome",
                //ImageURL = "www.imgUrl.com"



            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("ImageURL cannot be null or empty", e.Message);
        }
    }
}