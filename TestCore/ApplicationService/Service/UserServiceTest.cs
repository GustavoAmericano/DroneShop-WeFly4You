using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Moq;
using Xunit;

namespace TestCore
{
    public class UserServiceTest
    {
        #region GetAllUsers
        [Fact]
        public void GetAllUsersEnsureRepositoryIsCalled()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var isCalled = false;

            userRepo.Setup(x => x.GetAll()).Callback(() => isCalled = true).Returns(new List<User>());

            userService.GetAllUsers();
            
            Assert.True(isCalled);
        }
        #endregion

        #region ReadUserById
        [Fact]
        public void GetUserByIdEnsureRepositoryIsCalled()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            var isCalled = false;

            userRepo.Setup(x => x.GetUserById(user.Id)).Callback(() => isCalled = true).Returns(user);

            userService.ReadUserById(user.Id);
            
            Assert.True(isCalled);
        }

        [Fact]
        public void GetUserByIdWithIdLowerThan1ThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 0,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.ReadUserById(user.Id));
            
            Assert.Equal("The Id entered has to be at least 1", e.Message);
        }
        
        [Fact]
        public void GetUserByIdWithNoUserFoundThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            userRepo.Setup(x => x.GetUserById(user.Id)).Returns(() => user = null);
            
            var e = Assert.Throws<ArgumentException>(() => userService.ReadUserById(user.Id));
            
            Assert.Equal("Could not find any user with the entered id", e.Message);
        }
        #endregion

        #region CreateUser

        [Fact]
        public void CreateUserWithoutUsernameThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.CreateUser(user));
            
            Assert.Equal("The user needs to have a username", e.Message);
        }
        
        [Fact]
        public void CreateUserWithoutPasswordHashThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.CreateUser(user));
            
            Assert.Equal("The user needs to have both passwords", e.Message);
        }
        
        [Fact]
        public void CreateUserWithoutPasswordSaltThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.CreateUser(user));
            
            Assert.Equal("The user needs to have both passwords", e.Message);
        }
        
        [Fact]
        public void CreateUserEnsureRepositoryIsCalled()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            var isCalled = false;

            userRepo.Setup(x => x.Create(user)).Callback(() => isCalled = true).Returns(user);

            userService.CreateUser(user);
            
            Assert.True(isCalled);
        }

        #endregion

        #region UpdateUser

        [Fact]
        public void UpdateUserWithoutUsernameThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.UpdateUser(user));
            
            Assert.Equal("The user needs to have a username", e.Message);
        }
        
        [Fact]
        public void UpdateUserWithoutPasswordHashThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.UpdateUser(user));
            
            Assert.Equal("The user needs to have both passwords", e.Message);
        }
        
        [Fact]
        public void UpdateUserWithoutPasswordSaltThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.UpdateUser(user));
            
            Assert.Equal("The user needs to have both passwords", e.Message);
        }
        
        [Fact]
        public void UpdateUserEnsureRepositoryIsCalled()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 1,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            var isCalled = false;

            userRepo.Setup(x => x.Update(user)).Callback(() => isCalled = true).Returns(user);

            userService.UpdateUser(user);
            
            Assert.True(isCalled);
        }

        #endregion

        #region DeleteUser

         [Fact]
         public void DeleteUserEnsureRepositoryIsCalled()
           {
                var userRepo = new Mock<IUserRepository>();
                IUserService userService = new UserService(userRepo.Object);

                var user = new User()
                {
                    Id = 1,
                    Username = "Admin",
                    PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                    PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                    IsAdmin = true
                };
                var isCalled = false;

                userRepo.Setup(x => x.Delete(user.Id)).Callback(() => isCalled = true).Returns(user);

                userService.DeleteUser(user.Id);
            
                Assert.True(isCalled);
           }
        
        [Fact]
        public void DeleteUserWithIdLowerThan1ThrowsException()
        {
            var userRepo = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepo.Object);

            var user = new User()
            {
                Id = 0,
                Username = "Admin",
                PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)),
                PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)),
                IsAdmin = true
            };
            
            var e = Assert.Throws<ArgumentException>(() => userService.DeleteUser(user.Id));
            
            Assert.Equal("The Id entered has to be at least 1", e.Message);
        }
        
        
        

        #endregion
    }
}