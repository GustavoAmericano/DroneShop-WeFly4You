using System.Collections.Generic;
using System.Linq;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

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
            return _ctx.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            _ctx.Customers.Attach(customer).State = EntityState.Added;
            _ctx.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _ctx.Customers.Attach(customer).State = EntityState.Modified;
            _ctx.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            var custRemoved = _ctx.Remove(new Customer() {Id = id}).Entity;
            _ctx.SaveChanges();
            return custRemoved;
        }
    }
}