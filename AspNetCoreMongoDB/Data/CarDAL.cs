using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMongoDB.Core.Mongo.Context;
using AspNetCoreMongoDB.Core.Mongo.Repository;
using AspNetCoreMongoDB.Core.Mongo.UoW;
using AspNetCoreMongoDB.DTO.Car;
using AspNetCoreMongoDB.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AspNetCoreMongoDB.Data
{
    public class CarDAL : Repository<Cars>, ICarDAL
    {
        private readonly IMapper _mapper;
        private readonly IMongoContext _context;
        private readonly IMongoCollection<Markalar> _brands;

        public CarDAL(IMongoContext context, IUnitOfWork uow, IMapper mapper) : base(context, uow)
        {
            _mapper = mapper;
            _context = context;
            _brands = _context.GetCollection<Markalar>("Markalar");
        }
        
        public void MongoTest()
        {
            ////https://mongodb.github.io/mongo-csharp-driver/2.7/reference/driver/expressions/#in
            ////https://mongodb.github.io/mongo-csharp-driver/2.7/reference/driver/crud/linq/
            ////https://mongodb.github.io/mongo-csharp-driver/2.7/reference/driver/definitions/
            ////https://code.tutsplus.com/tutorials/full-text-search-in-mongodb--cms-24835
            ////https://www.codeproject.com/Tips/1103809/MongoDb-Csharp-MongoClient-x-TextResearch-How-To-D
            ////https://mongodb.github.io/mongo-csharp-driver/2.5/getting_started/quick_tour/
            ////https://mongodb.github.io/mongo-csharp-driver/2.5/getting_started/admin_quick_tour/
            ////https://gist.github.com/a3dho3yn/91dcc7e6f606eaefaf045fc193d3dcc3
            ////https://gist.github.com/a3dho3yn/91dcc7e6f606eaefaf045fc193d3dcc3
            ////https://developer.mongodb.com/how-to/transactions-c-dotnet
            ///
            /// 
            ///

            MongoIndex().CreateOne(Builders<Cars>.IndexKeys.Text(x => x.Model));

            //var indexKeysBuilder = Builders<Cars>.IndexKeys;
            //var keys = indexKeysBuilder.Ascending(x => x.Brand).Descending(x => x.Price);
            //var b6 = MongoIndex().CreateOne(keys);
            ////var b6 = MongoIndex().CreateOne(keys, new CreateIndexOptions { Unique = true });

            //var projection = Builders<Cars>.Projection.MetaTextScore("score");
            //var doc2 = FindFluentByEq(new BsonDocument()).Project(projection).First();
            //var sortMeta = Builders<Cars>.Sort.MetaTextScore("score");
            //var doc3 = FindFluentByEq(new BsonDocument()).Sort(sortMeta);

        }

        public CarListResponseDTO FindId(CarListRequestDTO src)
        {
            return _mapper.Map<CarListResponseDTO>(Find(x => x.Id == src.Id));
        }

        public async Task<IEnumerable<CarListResponseDTO>> IEnumerableFindByAsync(CarListRequestDTO src)
        {
            return _mapper.Map<IEnumerable<CarListResponseDTO>>(await FindByIEnumerableAsync(x=> x.CarID== src.CarID)).OrderBy(x=> x.Year);
        }

        public IQueryable<CarListResponseDTO> IQueryableGetAll()
        {
            return GetAllIQueryable().ProjectTo<CarListResponseDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<IList<CarListResponseDTO>> IListGetAllAsync()
        {
            return _mapper.Map<IList<CarListResponseDTO>>(await GetAllIListAsync());
        }

        public async Task<IEnumerable<CarListResponseDTO>> IEnumerableAsync()
        {
            return _mapper.Map<IEnumerable<CarListResponseDTO>>(await GetAllIEnumerableAsync());
        }

        public CarListResponseDTO GetId(string id)
        {
            return _mapper.Map<CarListResponseDTO>(GetById(id));
        }

        public async Task<CarListResponseDTO> GetIdAsync(string id)
        {
            return _mapper.Map<CarListResponseDTO>(await GetByIdAsync(id));
        }

        [Obsolete]
        public async Task<long> AllCountAsync()
        {
            return await CountAllAsync();
        }

        [Obsolete]
        public async Task<long> FindCountAsync(CarListRequestDTO src)
        {
            return await CountFindAsync(x => x.Brand == 3);
        }

        public IList<CarListResponseDTO> EqFindByList(CarListRequestDTO src)
        {
            // 1 Example
            /*
            var filterBuilder = Builders<Cars>.Filter;
            var filter = filterBuilder.Eq(x => x.Model, "1");
            filter = filter & (filterBuilder.Eq(x => x.Brand, 2) | filterBuilder.Eq(x => x.Year, 5));
            */

            // 2 Example
            /*
            var filterBuilder = Builders<Cars>.Filter;
            var filterb = filterBuilder.Gt(x=> x.Brand, 50) & filterBuilder.Lte(x => x.Brand, 100);
            var filterb = queryBuild.Eq(x => x.Brand, 1) & queryBuild.Lt(x => x.Year, 20);
            */

            // 3 Example
            var filter = Builders<Cars>.Filter.Eq(x => x.Brand, src.Brand);

            return _mapper.Map<IList<CarListResponseDTO>>(FindByEqIList(filter));
        }

        public IList<CarListResponseDTO> LinqFindFluentBy(CarListRequestDTO src)
        {
            var sort = Builders<Cars>.Sort.Ascending(u => u.Brand).Descending(u => u.CarID);

            // 1 Example
            var project = Builders<Cars>.Projection.Expression(x => new CarListResponseDTO { Brand = x.Brand, Model = x.Model, CarID= x.CarID, Year= x.Year });

            // 2 Example
            //var project = Builders<Cars>.Projection.Include(x => x.Price).Include(x => x.Model).Exclude(x => x.Id);
            //var project = Builders<Cars>.Projection.Expression(x => new { Brand = x.Brand, Model = x.Model, CarID = x.CarID, Year = x.Year });
            //var project = Builders<Cars>.Projection.Expression(x => new CarListResponseDTO { Brand = x.Brand, Model = x.Model, CarID = x.CarID, Year = x.Year });
            //var OnetherProject = cars.Find(_ => true).Project("{Model:1,_id: 0}").ToList();

            return FindFluentByLinq(x => x.Brand == src.Brand).Project(project).Sort(sort).Skip(src.Skip).Limit(src.Limit).ToList();
        }

        public async Task<IList<CarListResponseDTO>> LinqFindFluentByAsync(CarListRequestDTO src)
        {
            var sort = Builders<Cars>.Sort.Ascending(u => u.Brand).Descending(u => u.CarID);
            var project = Builders<Cars>.Projection.Expression(x => new CarListResponseDTO { Brand = x.Brand, Model = x.Model, CarID = x.CarID, Year = x.Year, Test = x.Year.ToString()  + x.Price.ToString() });
            //1 Example Sort
            //return await FindFluentByLinq(x => x.Brand == src.Brand).Project(project).Sort(sort).Skip(src.Skip).Limit(src.Limit).ToListAsync();
            
            //2 Example
            return await FindFluentByLinq(x => x.Brand == src.Brand).Project(project).SortBy(x=> x.Brand).Skip(src.Skip).Limit(src.Limit).ToListAsync();
        }

        public async Task<IEnumerable<CarListResponseDTO>> InExpressions(CarListRequestDTO src)
        {
            var filterBuilder = Builders<Cars>.Filter;
            var filter = filterBuilder.In(x => x.Brand, src.BrandArray);

            // 1 Linq In Example
            /*
            int[] localAges = new[] { 1, 20, 30 };
            var testIn = await FindFluentByLinq(x => localAges.Contains(x.Brand)).ToListAsync();
            */

            //1 Example
            //var filter = filterBuilder.In(x => x.Brand, src.BrandArray) & filterBuilder.Eq(x => x.Model , src.Model); //AND
            //var filter = filterBuilder.In(x => x.Brand, src.BrandArray) | filterBuilder.Eq(x => x.Model , src.Model); //OR
            //var project = Builders<Cars>.Projection.Expression(x => new CarListResponseDTO { Brand = x.Brand, Model = x.Model, CarID = x.CarID, Year = x.Year, Test = x.Year.ToString() + x.Price.ToString() });
            //return await FindFluentByEq(filter).Project(project).ToListAsync();

            //2 Example
            return _mapper.Map<IEnumerable<CarListResponseDTO>>(await FindFluentByEq(filter).ToListAsync());
        }

        public async Task<IEnumerable<CarBrandRelationshipDTO.Car>> CarBrandRelationship(CarListRequestDTO src)
        {
            /*
            var query = from c in cars.AsQueryable()
                        join m in markalar.AsQueryable() on
                 c.Brand equals m.brandid into j
                        select new { c, j };
            */

            /*
            var relationship = await AggregateBy().Lookup("Markalar", "Brand", "brandid", "Markalar").ToListAsync();
            return BsonSerializer.Deserialize<IEnumerable<CarBrandRelationshipDTO.Car>>(relationship.ToJson());
            */

            /*
            var relationship = await AggregateBy().Lookup("Markalar", "Brand", "brandid", "Markalar").Unwind("Markalar").As<CarListResponseDTO>().ToListAsync(); // show only submodel data
            return  BsonSerializer.Deserialize<IEnumerable<CarBrandRelationshipDTO.Car>>(relationship.ToJson());
            */

            //return _mapper.Map<IEnumerable<CarBrandRelationshipDTO.Car>>(await AggregateBy().Lookup("Markalar", "Brand", "brandid", "Markalar").Unwind("Markalar").As<Cars>().ToListAsync());
            //return await AggregateBy().Match(x => x.Brand == x.Brand).Lookup<Cars, Markalar, CarBrandRelationshipDTO.Car>(_brands, x => x.Brand, y => y.brandid, y => y.Markalar).ToListAsync();
            //return  _mapper.Map<IEnumerable<CarListResponseDTO>>(await AggregateBy().Lookup<Cars, Markalar, CarBrandRelationshipDTO.Car>(_brands, x => x.Brand, y => y.brandid, y => y.Markalar).SortBy(x => x.Brand).Skip(src.Skip).Limit(src.Limit).ToListAsync());


            //return await AggregateBy().Lookup<Cars, Markalar, CarBrandRelationshipDTO.Car>(_brands, x => x.Brand, y => y.brandid, y => y.Markalar).Unwind("Markalar").As<Markalar>().ToListAsync();
            return await AggregateBy().Lookup<Cars, Markalar, CarBrandRelationshipDTO.Car>(_brands, x => x.Brand, y => y.brandid, y => y.Markalar).ToListAsync();

        }

        public async Task<IEnumerable<CarBrandRelationshipDTO.Car>> CarBrandJoin(CarListRequestDTO src)
        {
           
            /*
            var projectn = Builders<Cars>.Projection.Expression(x => new CarListResponseDTO { Brand = x.Brand, Model = x.Model, CarID = x.CarID, Year = x.Year });
            var relationship = await AggregateBy().Match(x=> x.CarID>0).Project(projectn).Lookup("Markalar", "Brand", "brandid", "Markalar").ToListAsync();
            var result=  BsonSerializer.Deserialize<IEnumerable<CarBrandRelationshipDTO.Car>>(relationship.ToJson());
            */

            return await AggregateBy().Lookup<Cars, Markalar, CarBrandRelationshipDTO.Car>(_brands, x => x.Brand, y => y.brandid, y => y.Markalar).ToListAsync();
        }

        public IEnumerable<CarListResponseDTO> ElemMatchFindBy(CarListRequestDTO src)
        {
            var filterBuilder = Builders<Cars>.Filter;
            var filter = filterBuilder.ElemMatch(u => u.Comment, acc => acc.Name == src.CommentName);
            return _mapper.Map<IEnumerable<CarListResponseDTO>>(FindFluentByEq(filter).SortBy(x => x.Brand).Skip(src.Skip).Limit(src.Limit).ToList());
        }

        public IEnumerable<CarListResponseDTO> TextFindBy(CarListRequestDTO src)
        {
            var projectn = Builders<Cars>.Projection.Expression(x => new CarListResponseDTO { Brand = x.Brand, Model = x.Model, CarID = x.CarID, Year = x.Year });
            //return QueryableAs().WhereText(src.TextData).Take(10).ProjectTo<CarListResponseDTO>(_mapper.ConfigurationProvider);
            //return _mapper.Map<IEnumerable<CarListResponseDTO>>(FindFluentByEq(Builders<Cars>.Filter.Text(src.TextData, "english")));
            return FindFluentByEq(Builders<Cars>.Filter.Text(src.TextData)).Project(projectn).ToList(); ;
        }

        public IEnumerable<CarListResponseDTO> QueryableAsFindBy(CarListRequestDTO src)
        {
            return QueryableAs().Where(x=> x.Brand==src.Brand).OrderBy(x=> x.CarID).Skip(src.Skip).Take(src.Limit).ProjectTo<CarListResponseDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<bool> AddOneAsync(Cars dt)
        {
            return await AddAsync(dt);
        }

        public async Task<bool> AddManyAsync(IList<Cars> dt)
        {
            return await AddRangeAsync(dt);
        }

        public async Task<bool> InsertRelationshipAsync(Cars dt)
        {
            var resultCars = await AddOneAsync(dt);
            if (resultCars == true)
            { 
                await _brands.InsertManyAsync(dt.Markalar); 
            }
            return resultCars;
        }

        public async Task<bool> DeleteOneAsync(CarListRequestDTO src)
        {
            return await DeleteAsync(x => x.Id == src.Id);
        }

        public async Task<bool> DeleteManyAsync(CarListRequestDTO src)
        {
            return await DeleteRangeAsync(x => x.Brand == src.Brand);
        }

        public async Task<bool> UpdateReplaceOneAsync(Cars dt)
        {
            return await UpdateReplaceOneAsync(x => x.Id == dt.Id, dt);
        }

        public async Task<bool> FindOneAndUpdate(Cars dt)
        {
            return await UpdateAndFindOneAsync(
                 Builders<Cars>.Filter.Eq(x => x.Id, dt.Id),
                 Builders<Cars>.Update.Set(x=> x.Model, dt.Model)
             );
        }

        public async Task<bool> UpdateOneAsync(Cars dt)
        {
            /*
            var filter = Builders<Cars>.Filter.Eq(x => x.Id, dt.Id);
            var update = Builders<Cars>.Update
                .Set(x => x.Brand, dt.Brand)
                .Set(x => x.Model, dt.Model);
            return await await UpdateAsync(filterbc, update);
            */

            var update = Builders<Cars>.Update
                .Set(x => x.Brand, dt.Brand)
                .Set(x => x.Model, dt.Model)
                .CurrentDate("lastModified");
            return await UpdateAsync(x => x.Id == dt.Id, update);
        }

        public async Task<bool> UpdateManyAsync(Cars dt)
        {
            var update = Builders<Cars>.Update
                .Set(x => x.Year, dt.Year)
                .Set(x => x.Model, dt.Model)
                .CurrentDate("lastModified");
            return await UpdateRangeAsync(x => x.Brand == dt.Brand, update);
        }

        public async Task<bool> UpdatePullFilterAsync(string name, CarListRequestDTO src)
        {
            var pullFilter = Builders<Cars>.Update.PullFilter(p => p.Comment, f => f.Name == name); //delete the field in the lower section
            return await UpdateAsync(x => x.Id == src.Id && x.Year == src.Year, pullFilter);
        }

        public async Task<bool> UpdateAddToSetAsync(CarListRequestDTO src, Comment dt)
        {
            var filter = Builders<Cars>.Filter.Eq(x => x.Id, src.Id);
            var update = Builders<Cars>.Update.AddToSet<Comment>(x => x.Comment, dt);
            return await UpdateAsync(filter, update);
        }

        public async Task<bool> UpdateManyAddToSetAsync(CarListRequestDTO src, IList<Comment> dt)
        {
            var filter = Builders<Cars>.Filter.Eq(x => x.Id, src.Id);
            var update = Builders<Cars>.Update.AddToSetEach<Comment>(x => x.Comment, dt);
            return await UpdateRangeAsync(filter, update);
        }

        public async Task<bool> UpdateElemMatchAsync(CarListRequestDTO src, string commentname)
        {
            var filter = Builders<Cars>.Filter
             .And(
                 Builders<Cars>.Filter.Eq(d => d.Id, src.Id),
                 Builders<Cars>.Filter.ElemMatch(x => x.Comment, p => p.Name == src.CommentName)
             );
            var update = Builders<Cars>.Update.Set("Comment.$.Message", commentname);
            return await UpdateAsync(filter, update);
        }

        public void UpdateFullAsync(CarListRequestDTO src)
        {
            var filter = Builders<Cars>.Filter.Eq(x => x.Year, 2020);
            var update = Builders<Cars>.Update.Rename(u => u.Model, "Modeli");
            UpdateRange(filter, update);

            var filter1 = Builders<Cars>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
            var update1 = Builders<Cars>.Update.Inc(u => u.Brand, 15); //brand üzerine +15 yapar
            //var update1 = Builders<Car>.Update.Unset(x => x.Model); //alını siler
            //var update1 = Builders<Car>.Update.Rename(u => u.Model, "Modeli");
            //var update1 = Builders<Car>.Update.Inc(u => u.Brand, 15).Set(x => x.Model, "51").Unset(x => x.Model);
            UpdateRange(filter1, update1);

            //var filter2 = Builders<Car>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
            //var update2 = Builders<Car>.Update.Inc(u => u.Brand, 15); //brand üzerine +15 yapar
            //var update2 = Builders<Car>.Update.Unset(x => x.Model); //alını siler
            //var update2 = Builders<Car>.Update.Rename(u => u.Model, "Modeli");
            //var update2 = Builders<Car>.Update.Inc(u => u.Brand, 15).Set(x => x.Model, "51").Unset(x => x.Model);
            //var update2 = Builders<Car>.Update.CurrentDate(x => x.Model);
            //var update2 = Builders<Car>.Update.Min(u => u.Brand, 18); // Brand Alanı 18 büyük olanları 18 olarak yap
            //var update2 = Builders<Car>.Update.Max(u => u.Brand, 18);
            //var update2 = Builders<Car>.Update.SetOnInsert(u => u.Brand, 18);
            //var result = cars.UpdateOne(filter2, update2);

            //var update = new UpdateDefinitionBuilder<Product>().Mul<Double>(r => r.Price, 1.1);
            //await products.UpdateManyAsync(filter, update); //,options);
        }
    }
}
