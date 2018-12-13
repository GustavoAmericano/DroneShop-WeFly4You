using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.DomainService
{
    public interface IPackageRepository
    {
        Package Create(Package package);
        IEnumerable<Package> GetAllPackages();
        Package Update(Package packUpdate);
        Package Delete(int id);
        Package ReadById(int id);
    }
}
