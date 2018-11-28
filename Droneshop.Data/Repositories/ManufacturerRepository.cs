using System.Collections.Generic;
using System.Linq;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Droneshop.Data.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DroneShopContext _ctx;

        public ManufacturerRepository(DroneShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Manufacturer> GetAllManufacturers(Filter filter)
        {
            if (filter.ItemsPerPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.Manufacturers;
            }

            return _ctx.Manufacturers.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            _ctx.Attach(manufacturer).State = EntityState.Added;
            _ctx.SaveChanges();
            return manufacturer;
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