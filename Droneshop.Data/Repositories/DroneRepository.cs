using Droneshop.Core.DomainService;
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

        public FilteredList<Drone> GetAllDronesIncludeManufacturers()
        {
            var filteredList = new FilteredList<Drone> {List = _ctx.Drones.Include(d => d.Manufacturer), Count = _ctx.Drones.Count()};
            return filteredList;
        }

        public Drone Create(Drone drone)
        {
            _ctx.Attach(drone).State = EntityState.Added;
            _ctx.SaveChanges();

            return drone;
        }

        public Drone Delete(int id)
        {
            var droneDelete = _ctx.Remove(new Drone { Id = id }).Entity;
            _ctx.SaveChanges();
            return droneDelete;
        }

        public FilteredList<Drone> GetAllDrones(Filter filter)
        {
            var filteredList = new FilteredList<Drone>();

            if (filter != null && filter.ItemsPerPage > 0 && filter.CurrentPage > 0 && filter.IsSortedDescendingByPrice && filter.ManufacturerId != 0)
            {
                filteredList.List = _ctx.Drones
                    .Include(d => d.Manufacturer)
                    .Where(d => d.Manufacturer.Id == filter.ManufacturerId)
                    .OrderByDescending(drone => drone.Price)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                    .Take(filter.ItemsPerPage);

                filteredList.Count = _ctx.Drones
                    .Include(d => d.Manufacturer)
                    .Where(d => d.Manufacturer.Id == filter.ManufacturerId).Count();

                return filteredList;
            }
            
            if (filter != null && filter.ItemsPerPage > 0 && filter.CurrentPage > 0 && !filter.IsSortedDescendingByPrice && filter.ManufacturerId != 0)
            {
                filteredList.List = _ctx.Drones
                    .Include(d => d.Manufacturer)
                    .Where(d => d.Manufacturer.Id == filter.ManufacturerId)
                    .OrderBy(drone => drone.Price)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                    .Take(filter.ItemsPerPage);
                
                filteredList.Count = _ctx.Drones
                    .Include(d => d.Manufacturer)
                    .Where(d => d.Manufacturer.Id == filter.ManufacturerId).Count();
                
                return filteredList;
            }

            if (filter != null && filter.ItemsPerPage > 0 && filter.CurrentPage > 0 && !filter.IsSortedDescendingByPrice && filter.ManufacturerId == 0)
            {
                filteredList.List = _ctx.Drones
                    .Include(d => d.Manufacturer)
                    .OrderBy(drone => drone.Price)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                    .Take(filter.ItemsPerPage);

                filteredList.Count = _ctx.Drones.Count();

                return filteredList;
            }

            if (filter != null && filter.ItemsPerPage > 0 && filter.CurrentPage > 0 && filter.IsSortedDescendingByPrice && filter.ManufacturerId == 0)
            {
                filteredList.List = _ctx.Drones
                    .Include(d => d.Manufacturer)
                    .OrderBy(drone => drone.Price)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                    .Take(filter.ItemsPerPage);

                filteredList.Count = _ctx.Drones.Count();

                return filteredList;
            }

            filteredList.List = _ctx.Drones;
            filteredList.Count = _ctx.Drones.Count();
            return filteredList;
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
