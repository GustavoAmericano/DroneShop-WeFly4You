using Droneshop.Core.ApplicationService;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCore.ApplicationService.Service
{
    public class OrderServiceTest
    {
        #region ReadAllOrders
        [Fact]
        public void ReadAllOrdersEnsureRepositoryIsCalled()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var isCalled = false;

            orderRepo.Setup(x => x.GetAllOrders()).Callback(() => isCalled = true).Returns(new List<Order>());

            service.GetAllOrders();
            Assert.True(isCalled);


        }
        #endregion


        #region CreateOrder
        [Fact]
        public void CreateOrderEnsureRepositoryIsCalled()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var isCalled = false;

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    { 
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            orderRepo.Setup(x => x.CreateOrder(order)).Callback(() => isCalled = true).Returns(new Order());

            service.CreateOrder(order);
            Assert.True(isCalled);


        }

        

        [Fact]
        public void CreateOrderNoCustomerException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                /*Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                */
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.CreateOrder(order));
            Assert.Equal("Customer Cannot Be Null or Empty", e.Message);

        }

        [Fact]
        public void CreateOrderNoOrderLineException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                /*
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }*/

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.CreateOrder(order));
            Assert.Equal("OrderLine Cannot Be Null or Empty", e.Message);

        }
        #endregion


        #region UpdateOrder

        [Fact]
        public void UpdateOrderEnsureRepositoryIsCalled()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var isCalled = false;

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            orderRepo.Setup(x => x.UpdateOrder(order)).Callback(() => isCalled = true).Returns(new Order());

            service.UpdateOrder(order);
            Assert.True(isCalled);


        }

       

        [Fact]
        public void UpdateOrderNoCustomerException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                /*Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                */
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.UpdateOrder(order));
            Assert.Equal("Customer Cannot Be Null or Empty", e.Message);

        }

        [Fact]
        public void UpdateOrderNoOrderLineException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                /*
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }*/

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.UpdateOrder(order));
            Assert.Equal("OrderLine Cannot Be Null or Empty", e.Message);

        }


        #endregion


        #region DeleteOrder

        [Fact]
        public void DeleteOrderEnsureRepositoryIsCalled()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var isCalled = false;

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            orderRepo.Setup(x => x.DeleteOrder(order.Id)).Callback(() => isCalled = true).Returns(new Order());

            service.DeleteOrder(order.Id);
            Assert.True(isCalled);


        }

        [Fact]
        public void DeleteOrderIdAtleastOneException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 0,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.DeleteOrder(order.Id));
            Assert.Equal("The entered id has to be atleast 1", e.Message);

        }



        #endregion


        #region ReadOrderById

        [Fact]
        public void ReadOrderByIdEnsureRepositoryIsCalled()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var isCalled = false;

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            orderRepo.Setup(x => x.ReadOrderById(order.Id)).Callback(() => isCalled = true).Returns(new Order());
           

            service.ReadOrderById(order.Id);
            Assert.True(isCalled);


        }

        [Fact]
        public void ReadOrderByIdAtleastOneException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 0,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };

            Exception e = Assert.Throws<ArgumentException>(() => service.ReadOrderById(order.Id));
            Assert.Equal("The entered id has to be atleast 1", e.Message);

        }

        [Fact]
        public void ReadOrderByIdWithNoOrderFoundException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(orderRepo.Object);

            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "cust1",
                    LastName = "cust1",
                    Address = "testVej1",
                    Email = "test@test.test",
                    PhoneNumber = 12345678
                },
                
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                    DroneId = 1,
                    Drone = new Drone()
                    {
                        Id = 5,
                        Details = "Another drone",
                        ImageURL = "https://droner.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/a/large_e796da8a-a9c1-4dcb-b67e-dbc3c4acebfe.jpg",
                        Manufacturer = new Manufacturer()
                        {
                            Id = 1,
                            Name = "DJI"
                        },
                        ProductName = "Inspire 2 Cinema Pro",
                        Price = 151499
                    }

                    }
                }

            };
            orderRepo.Setup(x => x.ReadOrderById(order.Id)).Returns(() => order = null);

            var e = Assert.Throws<ArgumentException>(() => service.ReadOrderById(order.Id));
            Assert.Equal("Couldn't find any orders with the entered id", e.Message);

        }

        


        #endregion


    }
}
