using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Droneshop.Data.Repositories
{

    
    public class PackageRepository : IPackageRepository
    {
        public readonly DroneShopContext _ctx;

        public PackageRepository(DroneShopContext ctx)
        {
            _ctx = ctx;
        }

        public Package Create(Package package)
        {
            _ctx.Attach(package).State = EntityState.Added;
            _ctx.SaveChanges();
             return package;
        }

        public Package Delete(int id)
        {
            var packDelete = _ctx.Remove(new Package { Id = id }).Entity;
            _ctx.SaveChanges();
            return packDelete;
        }

        public IEnumerable<Package> GetAllPackages()
        {
            return _ctx.Packages;
        }

        public Package ReadById(int id)
        {
            return _ctx.Packages.FirstOrDefault(p => p.Id == id);
        }

        public Package Update(Package packUpdate)
        {
            _ctx.Packages.Attach(packUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return packUpdate;
        }
    }
}
