using System.Collections.Generic;
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

        public List<Manufacturer> GetAllManufacturers()
        {
            throw new System.NotImplementedException();
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