using System.Collections.Generic;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DroneShopContext _ctx;

        public CustomerRepository(DroneShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Customer> ReadAllCustomers()
        {
            return _ctx.Customers;
        }

        public Customer ReadCustomerById(int id)
        {
            throw new System.NotImplementedException();
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