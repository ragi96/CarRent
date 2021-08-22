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

        public Task Save(TDocument bookToSave);
        public Task<TDocument> GetById(string title);
        public Task<List<TDocument>> GetAll();
    }
}
