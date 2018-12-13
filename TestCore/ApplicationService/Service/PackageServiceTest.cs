using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCore.ApplicationService.Service
{
    public class PackageServiceTest
    {


        #region CreatePackageTest
        // testing whether or not an exception will be thrown if description is null
        [Fact]
        public void CreatePackageNoDescriptionException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()
            {
                Id = 1,
                //description = "hej"
                price = "500 pr billede"

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(package));
            Assert.Equal("description cannot be null or empty", e.Message);

        }
        [Fact]
        public void CreatePackageNoPriceException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()
            {
                Id = 2,
                description = "hej"
                //price = "500 pr billede"

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.Create(package));
            Assert.Equal("Price cannot be null or empty", e.Message);
        }

        #endregion

        #region UpdatePackageTest

        [Fact]
        public void UpdatePackageWithoutDescriptionException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()
            {
                Id = 1,
                //description = "hej"
                price = "500 pr billede"

            };

            var e = Assert.Throws<ArgumentException>(() => service.Update(package));

            Assert.Equal("description cannot be null or empty", e.Message);
        }

        [Fact]
        public void UpdatePackageWithoutPriceException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()
            {
                Id = 1,
                description = "hej"
                //price = "500 pr billede"

            };

            var e = Assert.Throws<ArgumentException>(() => service.Update(package));

            Assert.Equal("Price cannot be null or empty", e.Message);
        }
        #endregion

        #region DeletePackageTest
        [Fact]
        public void DeletePackageEnsureRepositoryIsCalled()
        {
            var isCalled = false;
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()

            {
                Id = 1,
                description = "hej",
                price = "500 pr billede"

            };
            packRepo.Setup(x => x.Delete(package.Id)).Callback(() => isCalled = true).Returns(new Package()
            {
                Id = 1,
                description = "hej",
                price = "500 pr billede"
            });
            service.Delete(package.Id);
            Assert.True(isCalled);


        }

        [Fact]
        public void DeletePackageWithIdLowerThan1ThrowsException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);

            Package package = new Package()

            {
                Id = 0,
                description = "hej",
                price = "500 pr billede"

            };
            var e = Assert.Throws<ArgumentException>(() => service.Delete(package.Id));

            Assert.Equal("The Id entered has to be at least 1", e.Message);

        }
        #endregion

        #region ReadPackageByIdTest
        [Fact]
        public void ReadPackageByIdEnsureRepositoryIsCalled()
        {
            var isCalled = false;
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()

            {
                Id = 1,
                description = "hej",
                price = "500 pr billede"

            };
            packRepo.Setup(x => x.ReadById(package.Id)).Callback(() => isCalled = true).Returns(new Package()
            {
                Id = 1,
                description = "hej",
                price = "500 pr billede"
            });
            service.ReadById(package.Id);
            Assert.True(isCalled);

        }
        [Fact]
        public void ReadPackageByIdWithIdLowerThan1ThrowsException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()

            {
                Id = 0,
                description = "hej",
                price = "500 pr billede"

            };
            var e = Assert.Throws<ArgumentException>(() => service.ReadById(package.Id));

            Assert.Equal("The Id entered has to be at least 1", e.Message);
        }

        [Fact]
        public void ReadDroneByIdWithNoDroneFoundThrowsException()
        {
            var packRepo = new Mock<IPackageRepository>();
            IPackageService service = new PackageService(packRepo.Object);
            Package package = new Package()

            {
                Id = 1,
                description = "hej",
                price = "500 pr billede"

            };
            packRepo.Setup(x => x.ReadById(package.Id)).Returns(() => package = null);

            var e = Assert.Throws<ArgumentException>(() => service.ReadById(package.Id));

            Assert.Equal("Could not find any packages with the entered id", e.Message);


        }
            #endregion
        }
}

