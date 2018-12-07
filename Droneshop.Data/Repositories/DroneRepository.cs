﻿using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Drone> GetAllDronesIncludeManufacturers()
        {
            return _ctx.Drones.Include(d => d.Manufacturer);
        }

        public Drone Create(Drone drone)
        {
            _ctx.Attach(drone).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _ctx.SaveChanges();

            return drone;
        }

        public Drone Delete(int id)
        {
            var droneDelete = _ctx.Remove(new Drone { Id = id }).Entity;
            _ctx.SaveChanges();
            return droneDelete;
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
            return _ctx.Drones.Include(d => d.Manufacturer).FirstOrDefault(d => d.Id == id); 
        }

        public Drone Update(Drone droneUpdate)
        {
            _ctx.Attach(droneUpdate).State = EntityState.Modified;

            _ctx.Entry(droneUpdate).Reference(d => d.Manufacturer).IsModified = true;
            
            _ctx.SaveChanges();
            
            return droneUpdate;
        }
    }
}
