using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.DomainService
{
    public interface IDroneRepository
    {
        IEnumerable<Drone> GetAllDrones(Filter filter = null);
        IEnumerable<Drone> GetAllDronesIncludeManufacturers();
        Drone Create(Drone drone);
        Drone ReadById(int id);
        Drone Delete(int id);
        Drone Update(Drone droneUpdate);
    }
}
