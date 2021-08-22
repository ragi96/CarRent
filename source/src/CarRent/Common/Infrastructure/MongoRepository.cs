
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public Task DeleteById(string id)
        {
            return DB.DeleteAsync<TDocument>(id);
        }

        public Task<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return DB.Find<TDocument>().ManyAsync(filterExpression);
        }

    }
}
