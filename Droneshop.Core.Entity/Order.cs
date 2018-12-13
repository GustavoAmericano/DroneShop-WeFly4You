using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OderDate { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; }

    }
}
