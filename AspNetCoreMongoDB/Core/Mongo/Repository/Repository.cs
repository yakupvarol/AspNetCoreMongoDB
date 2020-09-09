using AspNetCoreMongoDB.Core.Mongo.Context;
using AspNetCoreMongoDB.Core.Mongo.UoW;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Core.Mongo.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<T> _dbSet;
        protected readonly IUnitOfWork _uow;

        protected Repository(IMongoContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
            _dbSet = _context.GetCollection<T>(typeof(T).Name);
        }

        public virtual IQueryable<T> GetAllIQueryable()
        {
            return _dbSet.AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetAllIEnumerable()
        {
            return _dbSet.Find(Builders<T>.Filter.Empty).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllIEnumerableAsync()
        {
            var filter = await _dbSet.FindAsync(Builders<T>.Filter.Empty);
            return await filter.ToListAsync();
        }

        public virtual IList<T> GetAllIList()
        {
            return _dbSet.Find(Builders<T>.Filter.Empty).ToList();
        }

        public virtual async Task<IList<T>> GetAllIListAsync()
        {
            var filter = await _dbSet.FindAsync(Builders<T>.Filter.Empty);
            return await filter.ToListAsync();
        }

        public virtual ICollection<T> GetAllICollection()
        {
            return _dbSet.Find(Builders<T>.Filter.Empty).ToList();
        }

        public virtual async Task<ICollection<T>> GetAllICollectionAsync()
        {
            var filter = await _dbSet.FindAsync(Builders<T>.Filter.Empty);
            return await filter.ToListAsync();
        }

        public virtual T GetById(string id)
        {
            return _dbSet.Find(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var filter = await _dbSet.FindAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)));
            return await filter.FirstOrDefaultAsync();
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate).SingleOrDefault();
            //return _dbSet.AsQueryable<T>().FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Find(predicate).SingleOrDefaultAsync();

        public virtual IQueryable<T> FindByIQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable<T>().Where(predicate);
        }

        public virtual IEnumerable<T> FindByIEnumerable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate).ToList();
            //return _dbSet.AsQueryable<T>().Where(predicate).ToList();
        }

        public virtual IList<T> FindByIList(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate).ToList();
            //return _dbSet.AsQueryable<T>().Where(predicate).ToList();
        }

        public virtual ICollection<T> FindByICollection(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate).ToList();
            //return _dbSet.AsQueryable<T>().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> FindByIEnumerableAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Find(predicate).ToListAsync();
        }

        public virtual async Task<IList<T>> FindByIListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Find(predicate).ToListAsync();
        }

        public virtual async Task<ICollection<T>> FindByICollectionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Find(predicate).ToListAsync();
        }

        public virtual IEnumerable<T> FindByEqIEnumerable(FilterDefinition<T> predicate)
        {
            return _dbSet.Find(predicate).ToList();
        }

        public virtual IList<T> FindByEqIList(FilterDefinition<T> predicate)
        {
            return _dbSet.Find(predicate).ToList();
        }

        public virtual ICollection<T> FindByEqICollection(FilterDefinition<T> predicate)
        {
            return _dbSet.Find(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> FindByEqIEnumerableAsync(FilterDefinition<T> predicate)
        {
            var filter = await _dbSet.FindAsync(predicate);
            return await filter.ToListAsync();
        }

        public virtual async Task<IList<T>> FindByEqIListAsync(FilterDefinition<T> predicate)
        {
            var filter = await _dbSet.FindAsync(predicate);
            return await filter.ToListAsync();
        }

        public virtual async Task<ICollection<T>> FindByEqICollectionAsync(FilterDefinition<T> predicate)
        {
            var filter = await _dbSet.FindAsync(predicate);
            return await filter.ToListAsync();
        }

        public virtual IFindFluent<T,T> FindFluentByLinq(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate);
        }

        public virtual IFindFluent<T, T> FindFluentByEq(FilterDefinition<T> predicate)
        {
            return _dbSet.Find(predicate);
        }

        public virtual IAggregateFluent<T> AggregateBy()
        {
            return _dbSet.Aggregate();
        }

        public virtual IMongoQueryable<T> QueryableAs()
        {
            return _dbSet.AsQueryable<T>();
        }

        public virtual void Add(T obj)
        {
            _context.AddCommand(async () => await _dbSet.InsertOneAsync(obj));
            _uow.Commit();
        }

        public virtual async Task<bool> AddAsync(T obj)
        {
           _context.AddCommand(async () => await _dbSet.InsertOneAsync(obj));
            return await _uow.Commit();
        }

        public virtual void AddRange(IEnumerable<T> obj)
        {
            _context.AddCommand(async () => await _dbSet.InsertManyAsync(obj));
            _uow.Commit();
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> obj)
        {
            _context.AddCommand(async () => await _dbSet.InsertManyAsync(obj));
            return await _uow.Commit();
        }

        public virtual void AddRange(IList<T> obj)
        {
            _context.AddCommand(async () => await _dbSet.InsertManyAsync(obj));
            _uow.Commit();
        }

        public virtual async Task<bool> AddRangeAsync(IList<T> obj)
        {
            _context.AddCommand(async () => await _dbSet.InsertManyAsync(obj));
            return await _uow.Commit();
        }

        public void Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update, bool IsUpdateOptions)
        {
            if (IsUpdateOptions == false)
            { 
                _context.AddCommand(async () => { await _dbSet.UpdateOneAsync(predicate, update); }); 
            }
            else
            {
                _context.AddCommand(async () => { await _dbSet.UpdateOneAsync(predicate, update, new UpdateOptions { IsUpsert = true }); });
            }
            _uow.Commit();
        }

        public async Task<bool> UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.UpdateOneAsync(predicate, update);
            });
            return await _uow.Commit();
        }

        public void UpdateRange(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.UpdateManyAsync(predicate, update);
            });
            _uow.Commit();
        }

        public async Task<bool> UpdateRangeAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.UpdateManyAsync(predicate, update);
            });
            return await _uow.Commit();
        }

        public virtual void UpdateReplaceOne(Expression<Func<T, bool>> predicate,T obj)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.ReplaceOneAsync(predicate, obj);
            });
            _uow.Commit();
        }

        public virtual async Task<bool> UpdateReplaceOneAsync(Expression<Func<T, bool>> predicate, T obj)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.ReplaceOneAsync(predicate, obj);
            });
            return await _uow.Commit();
        }

        public void Update(FilterDefinition<T> predicate, UpdateDefinition<T> update, bool IsUpdateOptions)
        {
            if (IsUpdateOptions == false)
            {
                _context.AddCommand(async () => { await _dbSet.UpdateOneAsync(predicate, update); });
            }
            else
            {
                _context.AddCommand(async () => { await _dbSet.UpdateOneAsync(predicate, update, new UpdateOptions { IsUpsert = true }); });
            }
            _uow.Commit();
        }

        public async Task<bool> UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.UpdateOneAsync(predicate, update);
            });
            return await _uow.Commit();
        }

        public void UpdateRange(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.UpdateManyAsync(predicate, update);
            });
            _uow.Commit();
        }

        public async Task<bool> UpdateRangeAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.UpdateManyAsync(predicate, update);
            });
            return await _uow.Commit();
        }

        public virtual void UpdateReplaceOne(FilterDefinition<T> predicate, T obj)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.ReplaceOneAsync(predicate, obj);
            });
            _uow.Commit();
        }

        public virtual async Task<bool> UpdateReplaceOneAsync(FilterDefinition<T> predicate, T obj)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.ReplaceOneAsync(predicate, obj);
            });
            return await _uow.Commit();
        }

        public virtual void UpdateAndFindOne(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.FindOneAndUpdateAsync(predicate, update);
            });
            _uow.Commit();
        }

        public virtual async Task<bool> UpdateAndFindOneAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            _context.AddCommand(async () =>
            {
                await _dbSet.FindOneAndUpdateAsync(predicate, update);
            });
           return await _uow.Commit();
        }

        public virtual void Remove(string id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))));
            _uow.Commit();
        }

        public virtual async Task<bool> RemoveAsync(string id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))));
            return await _uow.Commit();
        }

        public virtual void RemoveRange(string id)
        {
            _context.AddCommand(() => _dbSet.DeleteManyAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))));
            _uow.Commit();
        }

        public virtual async Task<bool> RemoveRangeAsync(string id)
        {
            _context.AddCommand(() => _dbSet.DeleteManyAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))));
           return await _uow.Commit();
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteOneAsync(dt));
            _uow.Commit();
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteOneAsync(dt));
            return await _uow.Commit();
        }

        public virtual void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteManyAsync(dt));
            _uow.Commit();
        }

        public virtual async Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteManyAsync(dt));
            return await _uow.Commit();
        }

        public virtual void DeleteAndFindOne(Expression<Func<T, bool>> predicate)
        {
            _context.AddCommand(() => _dbSet.FindOneAndDeleteAsync(predicate));
            _uow.Commit();
        }

        public virtual async Task<bool> DeleteAndFindOneAsync(Expression<Func<T, bool>> predicate)
        {
            _context.AddCommand(() => _dbSet.FindOneAndDeleteAsync(predicate));
            return await _uow.Commit();
        }

        public virtual void Delete(FilterDefinition<T> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteOneAsync(dt));
            _uow.Commit();
        }

        public virtual async Task<bool> DeleteAsync(FilterDefinition<T> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteOneAsync(dt));
            return await _uow.Commit();
        }

        public virtual void DeleteRange(FilterDefinition<T> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteManyAsync(dt));
            _uow.Commit();
        }

        public virtual async Task<bool> DeleteRangeAsync(FilterDefinition<T> predicate)
        {
            var dt = _dbSet.Find(predicate).Filter;
            _context.AddCommand(() => _dbSet.DeleteManyAsync(dt));
            return await _uow.Commit();
        }

        public virtual void DeleteAndFindOne(FilterDefinition<T> predicate)
        {
            _context.AddCommand(() => _dbSet.FindOneAndDeleteAsync(predicate));
            _uow.Commit();
        }

        public virtual async Task<bool> DeleteAndFindOneAsync(FilterDefinition<T> predicate)
        {
            _context.AddCommand(() => _dbSet.FindOneAndDeleteAsync(predicate));
            return await _uow.Commit();
        }


        [Obsolete]
        public long CountAll()
        {
            return _dbSet.Count(_ => true);
            //return _dbSet.AsQueryable<T>().Count();
        }

        [Obsolete]
        public async Task<long> CountAllAsync()
        {
            return await _dbSet.CountAsync(_ => true);
        }

        [Obsolete]
        public virtual long CountFind(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate);
            //return _dbSet.AsQueryable<T>().Where(predicate).Count();
        }

        [Obsolete]
        public virtual async Task<long> CountFindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public bool AnyBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Find(predicate).Any();
            //return _dbSet.AsQueryable<T>().Where(filter).Any();
        }

        public virtual async Task<bool> AnyByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Find(predicate).AnyAsync();
        }

        public virtual IMongoIndexManager<T> MongoIndex()
        {
            return _dbSet.Indexes;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
