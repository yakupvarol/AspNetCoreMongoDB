using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Helper
{
    public static class MongoQueryableFullTextExtensions
    {
        public static IMongoQueryable<T> WhereText<T>(this IMongoQueryable<T> query, string search)
        {
            var filter = Builders<T>.Filter.Text(search);
            return query.Where(_ => filter.Inject());
        }
    }
}
