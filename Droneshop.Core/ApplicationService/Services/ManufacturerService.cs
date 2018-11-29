using System;
using System.Collections.Generic;
using System.Linq;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        
        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public List<Manufacturer> GetAllManufacturers(Filter filter)
        {
            if (filter.ItemsPerPage < 0 || filter.CurrentPage < 0)
            {
                throw new ArgumentException("The items per page and current page have to be positive numbers");
            }
            return _manufacturerRepository.GetAllManufacturers(filter).ToList();
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer.Name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            return _manufacturerRepository.Create(manufacturer);
        }

        public Manufacturer ReadById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }

            var manufacturerFound = _manufacturerRepository.ReadById(id);
            
            if (manufacturerFound == null)
            {
                throw new ArgumentException("Could not find any manufacturer with the entered id");
            }
            return manufacturerFound;
        }

        public Manufacturer Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }
       
            return _manufacturerRepository.Delete(id);
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer.Name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }
            return _manufacturerRepository.Update(manufacturer);
        }
    }
}