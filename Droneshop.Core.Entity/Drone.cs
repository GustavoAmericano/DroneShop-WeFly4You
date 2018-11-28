using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.Entity
{
    public class Drone
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer  { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public string ImageURL { get; set; }
        
    }
}
