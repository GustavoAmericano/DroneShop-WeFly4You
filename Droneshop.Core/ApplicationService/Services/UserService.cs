using System;
using System.Collections.Generic;
using System.Linq;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Droneshop.Core.Helpers;

namespace Droneshop.Core.ApplicationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public User ReadUserById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }
            
            var userFound = _userRepository.GetUserById(id);

            if (userFound == null)
            {
                throw new ArgumentException("Could not find any user with the entered id");
            }

            return userFound;
        }

        public User CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("The user needs to have a username");
            }

            if (user.PasswordHash == null || user.PasswordSalt == null)
            {
                throw new ArgumentException("The user needs to have both passwords");
            }
            
            
            
            return _userRepository.Create(user);
        }

        public User UpdateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("The user needs to have a username");
            }

            if (user.PasswordHash == null || user.PasswordSalt == null)
            {
                throw new ArgumentException("The user needs to have both passwords");
            }
            
            return _userRepository.Update(user);
        }

        public User DeleteUser(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }
            return _userRepository.Delete(id);
        }
    }
}