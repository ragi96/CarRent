using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.ReservationManagement.Domain;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    [ExcludeFromCodeCoverage]
    public class _005_CreateReservationCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            await DB.CreateCollection(new CreateCollectionOptions<Reservation>());
        }
    }
}