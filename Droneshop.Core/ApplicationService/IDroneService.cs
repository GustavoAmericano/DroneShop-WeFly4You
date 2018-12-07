using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.ApplicationService
{
    public interface IDroneService
    {
        List<Drone> GetAllDrones(Filter filter);
        List<Drone> GetAllDronesIncludeManufacturers();
        Drone Create(Drone drone);
        Drone ReadById(int id);
        Drone Delete(int id);
        Drone Update(Drone droneUpdate);
    }
}
