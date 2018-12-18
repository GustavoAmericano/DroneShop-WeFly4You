using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Droneshop.Core.DomainService;
using Droneshop.Core.Entity;

namespace Droneshop.Core.ApplicationService.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _PackRepo;
        public PackageService(IPackageRepository PackRepo)
        {
            _PackRepo = PackRepo;
        }


        public Package Create(Package package)
        {
            ValidateData(package);
            return _PackRepo.Create(package);
        }

        public Package Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }
            return _PackRepo.Delete(id);
        }

        public List<Package> GetAllPackages()
        {
            return _PackRepo.GetAllPackages().ToList();
        }

        public Package ReadById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("The Id entered has to be at least 1");
            }
            var PackFound = _PackRepo.ReadById(id);

            if (PackFound == null)
            {
                throw new ArgumentException("Could not find any packages with the entered id");
            }

            return PackFound;
        }

        public Package Update(Package packUpdate)
        {
            ValidateData(packUpdate);
            return _PackRepo.Update(packUpdate);
        }



        private void ValidateData(Package package)
        {
            if (package.Id < 0)
            {
                throw new ArgumentException("Package id must be higher than 0");
            }

            else if (string.IsNullOrEmpty(package.description))
            {
                throw new ArgumentException("description cannot be null or empty");
            }

            else if (string.IsNullOrEmpty(package.price))
            {
                throw new ArgumentException("Price cannot be null or empty");
            }

         
            }
        }
    }

