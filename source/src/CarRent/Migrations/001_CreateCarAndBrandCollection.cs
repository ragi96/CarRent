using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using MongoDB.Driver.Core.Operations;
using MongoDB.Entities;

namespace CarRent.Migrations
{

    [ExcludeFromCodeCoverage]
    public class _001_CreateCarAndBrandCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            await DB.CreateCollection(new CreateCollectionOptions<Brand>());
            await DB.CreateCollection(new CreateCollectionOptions<CarClass>());
            await DB.CreateCollection(new CreateCollectionOptions<Car>());
        }
    }

}
