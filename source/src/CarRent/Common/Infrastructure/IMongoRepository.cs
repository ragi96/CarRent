using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Entities;

namespace CarRent.Common.Infrastructure
{
    public interface IMongoRepository<TDocument> where TDocument : IEntity
    {

        public Task Save(TDocument toSave);
        public Task<TDocument> GetById(string id);
        public Task<List<TDocument>> GetAll();
        public Task DeleteById(string id);
        public Task<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression);
    }
}
