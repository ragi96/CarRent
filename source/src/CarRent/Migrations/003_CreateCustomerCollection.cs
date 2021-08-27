
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CarRent.Migrations
{

    [ExcludeFromCodeCoverage]
    public class _003_CreateCustomerCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            await DB.CreateCollection(new CreateCollectionOptions<Customer>());
        }
    }

}
