using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.Entity
{
    public class OrderLine
    {
        public int DroneId { get; set; }
        public Drone Drone { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
        public double BoughtPrice { get; set; }

    }
}
