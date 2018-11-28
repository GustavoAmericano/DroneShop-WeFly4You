using System.Collections.Generic;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Data.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public IEnumerable<Manufacturer> GetAllManufacturers(Filter filter)
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