using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Data.Repositories
{
    public class DroneRepository : IDroneRepository
    {
        public readonly DroneShopContext _ctx;

        public DroneRepository(DroneShopContext ctx)
        {
            _ctx = ctx;
        }

        public Drone Create(Drone drone)
        {
            _ctx.Attach(drone).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _ctx.SaveChanges();

            return drone;
        }

        public Drone Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drone> GetAllDrones(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Drone ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Drone Update(Drone droneUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
