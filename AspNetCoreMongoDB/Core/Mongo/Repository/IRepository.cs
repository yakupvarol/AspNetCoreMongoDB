using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Core.Mongo.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAllIQueryable();
        IEnumerable<T> GetAllIEnumerable();
        Task<IEnumerable<T>> GetAllIEnumerableAsync();
        IList<T> GetAllIList();
        Task<IList<T>> GetAllIListAsync();
        ICollection<T> GetAllICollection();
        Task<ICollection<T>> GetAllICollectionAsync();
        T GetById(string id);
        Task<T> GetByIdAsync(string id);
        T Find(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindByIQueryable(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindByIEnumerable(Expression<Func<T, bool>> predicate);
        IList<T> FindByIList(Expression<Func<T, bool>> predicate);
        ICollection<T> FindByICollection(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByIEnumerableAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> FindByIListAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByICollectionAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindByEqIEnumerable(FilterDefinition<T> predicate);
        IList<T> FindByEqIList(FilterDefinition<T> predicate);
        ICollection<T> FindByEqICollection(FilterDefinition<T> predicate);
        Task<IEnumerable<T>> FindByEqIEnumerableAsync(FilterDefinition<T> predicate);
        Task<IList<T>> FindByEqIListAsync(FilterDefinition<T> predicate);
        Task<ICollection<T>> FindByEqICollectionAsync(FilterDefinition<T> predicate);
        IFindFluent<T, T> FindFluentByLinq(Expression<Func<T, bool>> predicate);
        IFindFluent<T, T> FindFluentByEq(FilterDefinition<T> predicate);
        IAggregateFluent<T> AggregateBy();
        IMongoQueryable<T> QueryableAs();

        void Add(T obj);
        Task<bool> AddAsync(T obj);
        void AddRange(IEnumerable<T> obj);
        Task<bool> AddRangeAsync(IEnumerable<T> obj);
        void AddRange(IList<T> obj);
        Task<bool> AddRangeAsync(IList<T> obj);


        void Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update, bool IsUpdateOptions);
        Task<bool> UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        void UpdateRange(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);
        Task<bool> UpdateRangeAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update);

        void Update(FilterDefinition<T> predicate, UpdateDefinition<T> update, bool IsUpdateOptions);
        Task<bool> UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        void UpdateRange(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task<bool> UpdateRangeAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        void UpdateReplaceOne(Expression<Func<T, bool>> predicate, T obj);
        Task<bool> UpdateReplaceOneAsync(Expression<Func<T, bool>> predicate, T obj);
        void UpdateAndFindOne(FilterDefinition<T> predicate, UpdateDefinition<T> update);
        Task<bool> UpdateAndFindOneAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update);

        void Remove(string id);
        Task<bool> RemoveAsync(string id);
        void RemoveRange(string id);
        Task<bool> RemoveRangeAsync(string id);
        void Delete(Expression<Func<T, bool>> predicate);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate);
        void DeleteRange(Expression<Func<T, bool>> predicate);
        Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate);
        void Delete(FilterDefinition<T> predicate);
        Task<bool> DeleteAsync(FilterDefinition<T> predicate);
        void DeleteRange(FilterDefinition<T> predicate);
        Task<bool> DeleteRangeAsync(FilterDefinition<T> predicate);
        void DeleteAndFindOne(FilterDefinition<T> predicate);
        Task<bool> DeleteAndFindOneAsync(FilterDefinition<T> predicate);

        long CountAll();
        Task<long> CountAllAsync();
        long CountFind(Expression<Func<T, bool>> predicate);
        Task<long> CountFindAsync(Expression<Func<T, bool>> predicate);

        bool AnyBy(Expression<Func<T, bool>> predicate);
        Task<bool> AnyByAsync(Expression<Func<T, bool>> predicate);

        IMongoIndexManager<T> MongoIndex();
    }
}
