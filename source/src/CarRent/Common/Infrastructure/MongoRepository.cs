using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.Common.Application;
using CarRent.Common.Domain;
using CarRent.Connection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Entities;

namespace CarRent.Common.Infrastructure
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : IEntity
    {
        public Task Save(TDocument toSave)
        {
            return toSave.SaveAsync();
        }

        public Task<List<TDocument>> GetAll()
        {
            return DB.Find<TDocument>()
                .Match(_ => true)
                .ExecuteAsync();
        }

        public Task<TDocument> GetById(string id)
        {
            return DB.Find<TDocument>()
                .Match(b => b.ID == id)
                .ExecuteSingleAsync();
        }
    }
}
