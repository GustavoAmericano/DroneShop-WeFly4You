using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService.Services
{
    public class DroneService : IDroneService
    {
        private readonly IDroneRepository _droneRepo;

        public DroneService(IDroneRepository repo)
        {
            _droneRepo = repo;
        }

        public Drone Create(Drone drone)
        {
            ValidateData(drone);
            return _droneRepo.Create(drone);
        }

        public Drone Delete(int id)
        {
            if(id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }

            if(_droneRepo.Delete(id) == null)
            {
                throw new ArgumentException("Could not find any drones with the entered id");
            }

            return _droneRepo.Delete(id);
        }

        public List<Drone> GetAllDrones(Filter filter)
        {
            if(filter.ItemsPerPage < 0 || filter.CurrentPage < 0)
            {
                throw new ArgumentException("The items per page and current page have to be positive numbers");
            }
            return _droneRepo.GetAllDrones(filter).ToList();
        }

        public Drone ReadById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }

            var droneFound = _droneRepo.ReadById(id);

            if (droneFound == null)
            {
                throw new ArgumentException("Could not find any drones with the entered id");
            }

            return droneFound;
        }

        public Drone Update(Drone droneUpdate)
        {
            ValidateData(droneUpdate);
            return _droneRepo.Update(droneUpdate);
        }

        public void ValidateData(Drone drone)
        {
            if(drone.Manufacturer == null)
            {
                throw new ArgumentException("Manufacturer cannot be null or empty");
            }

            else if(string.IsNullOrEmpty(drone.Model))
            {
                throw new ArgumentException("Model cannot be null or empty");
            }

            else if(drone.Price <= 0)
            {
                throw new ArgumentException("Price cannot be null or empty");
            }

            else if(string.IsNullOrEmpty(drone.Details))
            {
                throw new ArgumentException("Details cannot be null or empty");
            }

            else if(string.IsNullOrEmpty(drone.ImageURL))
            {
                throw new ArgumentException("ImageURL cannot be null or empty");
            }
        }
    }
}
