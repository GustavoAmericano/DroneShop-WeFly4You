using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User ReadUserById(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
        Customer GetUsersCustomerInfo(string username);

    }
}