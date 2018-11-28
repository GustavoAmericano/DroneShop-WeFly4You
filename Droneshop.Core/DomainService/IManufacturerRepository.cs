using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.DomainService
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> GetAllManufacturers(Filter filter);
        Manufacturer Create(Manufacturer manufacturer);
        Manufacturer ReadById(int id);
        Manufacturer Delete(int id);
        Manufacturer Update(Manufacturer manufacturer);
    }
}