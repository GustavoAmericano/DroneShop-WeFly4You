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
            throw new System.NotImplementedException();
        }

        public Manufacturer ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Manufacturer Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {
            throw new System.NotImplementedException();
        }
    }
}