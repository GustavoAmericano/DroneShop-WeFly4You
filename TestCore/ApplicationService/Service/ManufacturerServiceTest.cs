using System;
using System.Collections.Generic;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Moq;
using Xunit;

namespace TestCore
{
    public class ManufacturerServiceTest
    {
        
         
        [Fact]
        public void GetAllManufacturersEnsureRepositoryIsCalled()
        {
            var manufacturerRepo = new Mock<IManufacturerRepository>();
            IManufacturerService manufacturerService = new ManufacturerService(manufacturerRepo.Object);

            var isCalled = false;

            manufacturerRepo.Setup(x => x.GetAllManufacturers(It.IsAny<Filter>())).Callback(() => isCalled = true).Returns(new List<Manufacturer>()
            {
                new Manufacturer()
                {
                    Id = 1,
                    Name = "Test",
                    Drones = null                   
                }
            });

            manufacturerService.GetAllManufacturers(It.IsAny<Filter>());
            
            Assert.True(isCalled);
        }

        [Fact]
        public void GetAllManufacturersWithItemsPerPageIsNegativeThrowsException()
        {
            var manufacturerRepo = new Mock<IManufacturerRepository>();
            IManufacturerService manufacturerService = new ManufacturerService(manufacturerRepo.Object);
            
            var filter = new Filter()
            {
                ItemsPerPage = -1,
                CurrentPage = 1,
            };

            var e = Assert.Throws<ArgumentException>(() => manufacturerService.GetAllManufacturers(filter));
            
            Assert.Equal("The items per page and current page have to be positive numbers", e.Message);
        }
        
        [Fact]
        public void GetAllManufacturersWithCurrentPageIsNegativeThrowsException()
        {
            var manufacturerRepo = new Mock<IManufacturerRepository>();
            IManufacturerService manufacturerService = new ManufacturerService(manufacturerRepo.Object);
            
            var filter = new Filter()
            {
                ItemsPerPage = 1,
                CurrentPage = -1,
            };

            var e = Assert.Throws<ArgumentException>(() => manufacturerService.GetAllManufacturers(filter));
            
            Assert.Equal("The items per page and current page have to be positive numbers", e.Message);
        }
        
        

    }
}