using System;
using System.Collections.Generic;
using System.Linq;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> ReadAllCustomers()
        {
            return _customerRepository.ReadAllCustomers().ToList();
        }

        public Customer ReadCustomerById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }

            var customerFound = _customerRepository.ReadCustomerById(id);

            if (customerFound == null)
            {
                throw new NullReferenceException("Could not find any customer with the entered id");
            }

            return _customerRepository.ReadCustomerById(id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Customer DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}