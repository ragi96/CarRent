using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
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
            await DB.Index<Customer>()
                .Key(b => b.FirstName, KeyType.Text)
                .Key(b => b.LastName, KeyType.Text)
                .Key(b => b.Street, KeyType.Text)
                .Key(b => b.HouseNumber, KeyType.Text)
                .Key(b => b.Zip, KeyType.Text)
                .Key(b => b.City, KeyType.Text)
                .CreateAsync();
        }
    }
}