using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Drone> GetAllDrones(Filter filter)
        {
            if(filter.ItemsPerPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.Drones;
            }

            return _ctx.Drones.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
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
