using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.InvoiceManagement.Domain;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    [ExcludeFromCodeCoverage]
    public class _007_CreateInvoiceCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            await DB.CreateCollection(new CreateCollectionOptions<Invoice>());
        }
    }
}