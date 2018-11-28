using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.DomainService
{
    public interface IManufacturerRepository
    {
        List<Manufacturer> GetAllManufacturers(Filter filter =  null);
        Manufacturer Create(Manufacturer manufacturer);
        Manufacturer ReadById(int id);
        Manufacturer Delete(int id);
        Manufacturer Update(Manufacturer manufacturer);
    }
}