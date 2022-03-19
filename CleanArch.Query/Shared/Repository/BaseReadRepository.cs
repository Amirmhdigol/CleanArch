using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Shared.Repository
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
        private readonly IMongoCollection<TEntity> _collection;
        public BaseReadRepository(IMongoClient mongoClient)
        {
            var Database = mongoClient.GetDatabase("CleanArch");
            _collection = Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(a=>a.Id==id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            var res = await _collection.FindAsync(r => true);
            return res.ToList();
        }

        public async Task<TEntity> GetById(long id)
        {
            var res = await _collection.FindAsync(a => a.Id == id);
            return res.FirstOrDefault();
        }

        public async Task Insert(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _collection.ReplaceOneAsync(a=>a.Id == entity.Id, entity);
        }
    }
}
