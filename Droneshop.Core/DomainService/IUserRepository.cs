using System.Collections;
using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.DomainService
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User Create(User user);
        User Update(User user);
        User Delete(int id);
        Customer GetUsersCustomerInfo(string username);
    }
}