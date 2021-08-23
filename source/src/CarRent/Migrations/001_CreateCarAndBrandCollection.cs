using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    public class _001_CreateCarBrandCarClassCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            await DB.CreateCollection(new CreateCollectionOptions<Brand>());
            await DB.CreateCollection(new CreateCollectionOptions<CarClass>());
            await DB.CreateCollection(new CreateCollectionOptions<Car>());
        }
    }
}
