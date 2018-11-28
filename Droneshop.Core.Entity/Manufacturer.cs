using System.Collections.Generic;

namespace Droneshop.Core.Entity
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Drone> Drones { get; set; }
    }
}