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
    public class CustomerServiceTest
    {

        #region ReadAllCustomers

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
        
        #endregion

        #region ReadCustomerById

        [Fact]
        public void ReadCustomerByIdEnsureRepositoryIsCalled()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var isCalled = false;
            var customer = new Customer()
            {
                Id = 1,
            };

            customerRepo.Setup(x => x.ReadCustomerById(customer.Id)).Callback(() => isCalled = true).Returns(customer);

            customerService.ReadCustomerById(customer.Id);
            
            Assert.True(isCalled);
        }

        [Fact]
        public void ReadCustomerByIdWithIdLowerThan1ThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);
            var customer = new Customer()
            {
                Id = 0,
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.ReadCustomerById(customer.Id));
            
            Assert.Equal("The Id entered has to be at least 1", e.Message);
        }

        [Fact]
        public void ReadCustomerByIdWithNoCustomerFoundThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);
            var customer = new Customer()
            {
                Id = 1,
            };

            customerRepo.Setup(x => x.ReadCustomerById(customer.Id)).Returns(() => customer = null);

            var e = Assert.Throws<NullReferenceException>(() => customerService.ReadCustomerById(customer.Id));
            
            Assert.Equal("Could not find any customer with the entered id", e.Message);
        }

        #endregion
        
        #region CreateCustomer

        [Fact]
        public void CreateCustomerEnsureRepositoryIsCalled()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var isCalled = false;
            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            customerRepo.Setup(x => x.CreateCustomer(customer)).Callback(() => isCalled = true).Returns(customer);

            customerService.CreateCustomer(customer);
            
            Assert.True(isCalled);
        }

        [Fact]
        public void CreateCustomerWithoutFirstNameThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.CreateCustomer(customer));
            
            Assert.Equal("Firstname cannot be null or empty", e.Message);
        }

        [Fact]
        public void CreateCustomerWithoutLastNameThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.CreateCustomer(customer));
            
            Assert.Equal("Lastname cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void CreateCustomerWithoutAddressThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.CreateCustomer(customer));
            
            Assert.Equal("Address cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void CreateCustomerWithoutEmailThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.CreateCustomer(customer));
            
            Assert.Equal("Email cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void CreateCustomerWithoutPhoneNumberThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmail.com"
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.CreateCustomer(customer));
            
            Assert.Equal("PhoneNumber cannot be 0", e.Message);
        }

        #endregion

        #region UpdateCustomer

        [Fact]
        public void UpdateCustomerEnsureRepositoryIsCalled()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var isCalled = false;
            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            customerRepo.Setup(x => x.UpdateCustomer(customer)).Callback(() => isCalled = true).Returns(customer);

            customerService.UpdateCustomer(customer);
            
            Assert.True(isCalled);
        }

        [Fact]
        public void UpdateCustomerWithIdLowerThan1ThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 0,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(customer));
            
            Assert.Equal("Firstname cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void UpdateCustomerWithoutFirstNameThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(customer));
            
            Assert.Equal("Firstname cannot be null or empty", e.Message);
        }

        [Fact]
        public void UpdateCustomerWithoutLastNameThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                Address = "Testvej 11",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(customer));
            
            Assert.Equal("Lastname cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void UpdateCustomerWithoutAddressThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Email = "hans.hansen@gmai.com",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(customer));
            
            Assert.Equal("Address cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void UpdateCustomerWithoutEmailThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                PhoneNumber = 12345678
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(customer));
            
            Assert.Equal("Email cannot be null or empty", e.Message);
        }
        
        [Fact]
        public void UpdateCustomerWithoutPhoneNumberThrowsException()
        {
            var customerRepo = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepo.Object);

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Testvej 11",
                Email = "hans.hansen@gmail.com"
            };

            var e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(customer));
            
            Assert.Equal("PhoneNumber cannot be 0", e.Message);
        }

        #endregion
    }
}