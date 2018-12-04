using System.Collections.Generic;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Moq;
using Xunit;

namespace TestCore
{
    public class CustomerServiceTest
    {
        [Fact]
        public void ReadAllCustomersEnsureRepositoryIsCalled()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var isCalled = false;

            customerRepo.Setup(x => x.ReadAllCustomers()).Callback(() => isCalled = true).Returns(new List<Customer>());

            customerService.ReadAllCustomers();
            
            Assert.True(isCalled);
        }
    }
}