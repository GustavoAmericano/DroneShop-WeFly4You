using Droneshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droneshop.Core.ApplicationService.Services
{
    public interface IPackageService
    {
        Package Create(Package package);
        List<Package> GetAllPackages();
        Package Update(Package packUpdate);
        Package Delete(int id);
        Package ReadById(int id);
    }
}
