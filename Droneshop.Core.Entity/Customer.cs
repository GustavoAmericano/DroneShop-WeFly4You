using System.Collections.Generic;

namespace Droneshop.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Order> Order { get; set; }
    }
}