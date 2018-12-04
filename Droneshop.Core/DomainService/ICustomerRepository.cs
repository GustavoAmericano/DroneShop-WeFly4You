using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.DomainService
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadAllCustomers();

        Customer ReadCustomerById(int id);

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer DeleteCustomer(int id);
    }
}