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

        public async Task<List<TDocument>> GetAll()
        {
            return await DB.Find<TDocument>()
                .Match(_ => true)
                .ExecuteAsync();
        }

        public async Task<TDocument> GetById(string id)
        {
            return await DB.Find<TDocument>()
                .Match(b => b.ID == id)
                .ExecuteSingleAsync();
        }

        public Task DeleteById(string id)
        {
            return DB.DeleteAsync<TDocument>(id);
        }

        public async Task<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return await DB.Find<TDocument>().ManyAsync(filterExpression);
        }

        public async Task<List<TDocument>> FuzzySearch(string searchTerm)
        {
            return await DB.Find<TDocument>()
                .Match(Search.Fuzzy, searchTerm)
                .ExecuteAsync();
        }
    }
}