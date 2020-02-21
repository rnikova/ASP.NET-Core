using Panda.Domain;
using System.Linq;

namespace Panda.Services
{
    public interface IPackagesService
    {
        void CreatePackage(Package package);

        Package GetPackage(string id);

        PackageStatus GetPackageStatus(string status);

        void UpdatePackage(Package package);

        IQueryable<Package> GetPackagesWithRecipientAndStatus();
    }
}
