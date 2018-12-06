using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OderDate { get; set; }
        public Customer Cust { get; set; }

    }
}
