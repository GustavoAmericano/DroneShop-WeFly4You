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

            manufacturerRepo.Setup(x => x.GetAllManufacturers(It.IsAny<Filter>())).Callback(() => isCalled = true);

            manufacturerService.GetAllManufacturers();
            
            Assert.True(isCalled);

        }
    }
}