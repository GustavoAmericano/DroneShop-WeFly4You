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
        #region ReadAllDroneTest

        [Fact]
        public void ReadAllDronesEnsureRepositoryIsCalled()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);

            var isCalled = false;
            var filter = new Filter();

            droneRepo.Setup(x => x.GetAllDrones(filter)).Callback(() => isCalled = true)
                .Returns(new FilteredList<Drone>());

            service.GetAllDrones(filter);
            Assert.True(isCalled);

        }


        #endregion
        
        #region ReadAllDronesIncludeManufacturersTest

        [Fact]
        public void ReadAllDronesIncludeManufacturersEnsureRepositoryIsCalled()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService service = new DroneService(droneRepo.Object);

            var isCalled = false;

            droneRepo.Setup(x => x.GetAllDronesIncludeManufacturers()).Callback(() => isCalled = true).Returns(new FilteredList<Drone>());

            service.GetAllDronesIncludeManufacturers();
            Assert.True(isCalled);

        }
        
        #endregion

        #region CreateDroneTest
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
                ProductName = "B15",
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
                ProductName = "B15",
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
                //ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"


            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("ProductName cannot be null or empty", e.Message);
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
                ProductName = "B15",
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
                ProductName = "B15",
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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                //ImageURL = "www.imgUrl.com"



            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(drone));
            Assert.Equal("ImageURL cannot be null or empty", e.Message);
        }
        #endregion

        #region UpdateDrone
        [Fact]
        public void UpdateDroneEnsureRepositoryIsCalled()
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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"

            };

            droneRepo.Setup(x => x.Update(drone)).Callback(() => isCalled = true).Returns(new Drone()
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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            });

            service.Update(drone);
            Assert.True(isCalled);
        }

        [Fact]
        public void UpdateDroneWithoutManufacturerExeption()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

            var drone = new Drone()
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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.Update(drone));

            Assert.Equal("Manufacturer cannot be null or empty", e.Message);
        }

        [Fact]
        public void UpdateDroneWithoutModelExeption()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                //ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.Update(drone));

            Assert.Equal("ProductName cannot be null or empty", e.Message);
        }

        [Fact]
        public void UpdateDroneWithoutPriceExeption()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                ProductName = "B15",
                //Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.Update(drone));

            Assert.Equal("Price cannot be null or empty", e.Message);
        }

        [Fact]
        public void UpdateDroneWithoutDetailsExeption()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                ProductName = "B15",
                Price = 500,
                //Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.Update(drone));

            Assert.Equal("Details cannot be null or empty", e.Message);
        }

        [Fact]
        public void UpdateDroneWithoutImageURLExeption()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                //ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.Update(drone));

            Assert.Equal("ImageURL cannot be null or empty", e.Message);
        }

        #endregion

        #region DeleteDrone
        [Fact]
        public void DeleteDroneEnsureRepositoryIsCalled()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            droneRepo.Setup(x => x.Delete(drone.Id)).Callback(() => isCalled = true).Returns(new Drone()
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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            });

            droneService.Delete(drone.Id);
            Assert.True(isCalled);
        }

        [Fact]
        public void DeleteDroneWithIdLowerThan1ThrowsException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

            var drone = new Drone()
            {
                Id = 0,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.Delete(drone.Id));

            Assert.Equal("The Id entered has to be at least 1", e.Message);
        }
        #endregion

        #region ReadDroneById
        [Fact]
        public void ReadDroneByIdEnsureRepositoryIsCalled()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            droneRepo.Setup(x => x.ReadById(drone.Id)).Callback(() => isCalled = true).Returns(new Drone()
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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            });

            droneService.ReadById(drone.Id);
            Assert.True(isCalled);
        }

        [Fact]
        public void ReadDroneByIdWithIdLowerThan1ThrowsException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

            var drone = new Drone()
            {
                Id = 0,
                Manufacturer = new Manufacturer()
                {
                    Id = 1,
                    Name = "Phantom",
                    Drones = new List<Drone>()
                    {
                        new Drone()
                    }
                },
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            var e = Assert.Throws<ArgumentException>(() => droneService.ReadById(drone.Id));

            Assert.Equal("The Id entered has to be at least 1", e.Message);
        }

        [Fact]
        public void ReadDroneByIdWithNoDroneFoundThrowsException()
        {
            var droneRepo = new Mock<IDroneRepository>();
            IDroneService droneService = new DroneService(droneRepo.Object);

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
                ProductName = "B15",
                Price = 500,
                Details = "Handsome",
                ImageURL = "www.imgUrl.com"
            };

            droneRepo.Setup(x => x.ReadById(drone.Id)).Returns(() => drone = null);

            var e = Assert.Throws<ArgumentException>(() => droneService.ReadById(drone.Id));

            Assert.Equal("Could not find any drones with the entered id", e.Message);
        }
        #endregion



    }
}