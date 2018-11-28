using System;
using System.Collections.Generic;
using System.Text;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService.Services
{
    public class DroneService : IDroneService
    {
        public readonly IDroneRepository _droneRepo;

        public DroneService(IDroneRepository repo)
        {
            _droneRepo = repo;
        }

        public Drone Create(Drone drone)
        {
            try
            {
                ValidateData(drone);
            }

            catch(Exception e)
            {
                throw;
            }
            return _droneRepo.Create(drone);
        }

        public Drone Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drone> GetAllDrones()
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
