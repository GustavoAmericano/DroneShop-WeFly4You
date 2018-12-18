using System;
using System.Collections.Generic;
using System.Linq;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Droneshop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DroneShopContext _ctx;

        public UserRepository(DroneShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users;
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Create(User user)
        {
            var existingUser = _ctx.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                throw new ArgumentException("The username" + user.Username + "is already taken");
            }
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _ctx.Users.Remove(user);
            }

            _ctx.SaveChanges();
            return user;

        }

        public Customer GetUsersCustomerInfo(string username)
        {
            return _ctx.Customers.FirstOrDefault(c => c.User.Username == username);
        }
    }
}