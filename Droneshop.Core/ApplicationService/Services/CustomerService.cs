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
            VerifyCustomerInput(customer);
            return _customerRepository.CreateCustomer(customer);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer.Id < 1)
            {
                throw new ArgumentException("The Id cannot be less than 1");
            }
            VerifyCustomerInput(customer);
            return _customerRepository.UpdateCustomer(customer);
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        private void VerifyCustomerInput(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                throw new ArgumentException("Firstname cannot be null or empty");
            }
            
            if (string.IsNullOrEmpty(customer.LastName))
            {
                throw new ArgumentException("Lastname cannot be null or empty");
            }
            
            if (string.IsNullOrEmpty(customer.Address))
            {
                throw new ArgumentException("Address cannot be null or empty");
            }

            if (string.IsNullOrEmpty(customer.Email))
            {
                throw new ArgumentException("Email cannot be null or empty");
            }

            if (customer.PhoneNumber == 0)
            {
                throw new ArgumentException("PhoneNumber cannot be 0");
            }
        }
    }
}