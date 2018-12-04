using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService
{
    public interface ICustomerService
    {
        List<Customer> ReadAllCustomers();

        Customer ReadCustomerById(int id);

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer DeleteCustomer(int id);
    }
}