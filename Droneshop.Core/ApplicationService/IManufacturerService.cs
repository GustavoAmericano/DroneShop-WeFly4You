using System.Collections.Generic;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService
{
    public interface IManufacturerService
    {
        List<Manufacturer> GetAllManufacturers(Filter filter);
        List<Manufacturer> GetAllManufacturersIncludeDrones();
        Manufacturer Create(Manufacturer manufacturer);
        Manufacturer ReadById(int id);
        Manufacturer Delete(int id);
        Manufacturer Update(Manufacturer manufacturer);
    }
}