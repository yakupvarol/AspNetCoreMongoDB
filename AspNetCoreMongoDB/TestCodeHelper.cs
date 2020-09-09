using AspNetCoreMongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB
{
    public class TestCodeHelper
    {
        //private readonly IMongoCollection<BsonDocument> carstest;
        //private readonly IMongoCollection<Car> cars;
        //private readonly IMongoCollection<Marka> markalar;
        //private readonly IMongoCollection<BsonDocument> collection;


        //public CarService(IConfiguration config)
        //{
        //    MongoClient client = new MongoClient(config.GetConnectionString("CarGalleryDb"));
        //    IMongoDatabase database = client.GetDatabase("CarGalleryDb");
        //    carstest = database.GetCollection<BsonDocument>("Cars");
        //    cars = database.GetCollection<Car>("Cars");
        //    markalar = database.GetCollection<Marka>("Markalar");
        //    collection = database.GetCollection<BsonDocument>("store");
        //}

        //public void test()
        //{
        //    var doc2 = new BsonDocument
        //    {
        //        {"name", "BMW"},
        //        {"price", 34621}
        //    };

        //    carstest.InsertOne(doc2);

        //    cars.InsertOne(new Car
        //    {
        //        CarID = Random(),
        //        Brand = 3,
        //        Model = "2012",
        //        Price = 12,
        //        Year = 2020,
        //        ImageUrl = "deneme.jpg",
        //    });
        //    //-----------------

        //    var dt1 = new List<Car>
        //    {
        //        new Car { CarID=Random(), Brand=3, Model="2012", Price=12, Year=2020, ImageUrl="deneme.jpg"},
        //        new Car {CarID=Random(), Brand=3, Model="2013", Price=13, Year=2025, ImageUrl="5deneme.jpg"}
        //    };
        //    cars.InsertMany(dt1);
        //    //---------------

        //    var CarID = Random();
        //    var dt2 = new List<Car>
        //    {
        //        new Car { CarID=CarID, Brand=3, Model="2012", Price=12, Year=2020, ImageUrl="deneme.jpg", Comment = new List<Comment>
        //        {
        //            new Comment { CarID=CarID, Name ="Eyüp", Message="Test Mesajı" },
        //            new Comment {CarID=CarID,Name="Ensar", Message="Test Mesajı" }
        //        }}
        //    };
        //    cars.InsertMany(dt2);

        //    //updqte

        //    var update222 = Builders<Car>.Update.Set("Brand", 483);
        //    var cc88 = cars.UpdateOne(x => x.Id == "5e79dd10f8125027bc5871ac" && x.Year == 2020, update222);
        //    //-----------------

        //    var result1 = cars.FindOneAndUpdate(
        //        Builders<Car>.Filter.Eq(x => x.Id, "5e77c617c2fccd3fb4538987"),
        //        Builders<Car>.Update.Set("Brand", 222)
        //    );
        //    //-----------------

        //    var updatevvv = Builders<Car>.Update.PullFilter(p => p.Comment, f => f.Name == "Eyüp 111"); // alt bölümde geçen alanı silmek
        //    var ccvv = cars.UpdateOne(x => x.Id == "5e79dd10f8125027bc5871ac" && x.Year == 2020, updatevvv);
        //    //-----------------


        //    Car carIn = new Car { Id = "5e77c617c2fccd3fb4538987", CarID = Random(), Brand = 223, Model = "21012", Price = 12, Year = 2020, ImageUrl = "deneme.jpg" };
        //    cars.ReplaceOne(car => car.Id == "5e77c617c2fccd3fb4538987", carIn, new UpdateOptions { IsUpsert = true }); // upsert propertysi kayıt varsa update et yoksa yarat anlamı taşırken, multi ise şarta uyan tüm kayıtların mı yoksa ilkinin mi update edileceğini ayarlar.
        //    var cv = cars.ReplaceOne(b => b.CarID == 223202023549708, carIn);

        //    var filterbc = Builders<Car>.Filter.Eq(x => x.Id, "5e77c617c2fccd3fb4538987");
        //    var update = Builders<Car>.Update.Set("Brand", 483);
        //    var cc = cars.UpdateOne(filterbc, update);

        //    var filterbc1 = Builders<Car>.Filter.Eq(x => x.Id, "5e77c617c2fccd3fb4538987");
        //    var update2 = Builders<Car>.Update
        //   .Set(x => x.Brand, 112)
        //   .Set(x => x.Model, "501")
        //   .CurrentDate("lastModified");
        //    var cc1 = cars.UpdateOne(filterbc1, update2);

        //    var filterbcc = Builders<Car>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
        //    var update22 = Builders<Car>.Update.AddToSet<Comment>(x => x.Comment, new Comment { CarID = 22222, Name = "Eyüp", Message = "Test Mesajı" });
        //    var result = cars.UpdateOne(filterbcc, update22);
        //    //---------------

        //    var filterbccas = Builders<Car>.Filter.Eq(x => x.Year, 2020);
        //    //var updateBuilder =Builders<Car>.Filter.In(per => per.Model, new List<string> { "fethiye", "izmir" });
        //    var updateBuilder = Builders<Car>.Update.PullFilter(p => p.Comment,
        //           Builders<Comment>.Filter.In(per => per.Name, new List<string> { "fethiye", "izmir" }));
        //    var updateResult = cars.UpdateMany(filterbccas, updateBuilder);
        //    //---------------

        //    var dt11 = new List<Comment>
        //    {
        //        new Comment { CarID = 22222, Name = "Eyüp 111", Message = "Test Mesajı 33" },
        //        new Comment { CarID = 22222, Name = "Eyüp 222", Message = "Test Mesajı 44" }
        //    };
        //    var filterbcc12 = Builders<Car>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
        //    var update221 = Builders<Car>.Update.AddToSetEach<Comment>(x => x.Comment, dt11);
        //    var result12 = cars.UpdateMany(filterbcc12, update22);
        //    //---------------

        //    var filter255 = Builders<Car>.Filter
        //    .And(
        //        Builders<Car>.Filter.Eq(d => d.Id, "5e79dd10f8125027bc5871ac"),
        //        Builders<Car>.Filter.ElemMatch(x => x.Comment, p => p.Name == "Zümra")
        //    );
        //    var incAge121 = Builders<Car>.Update.Set("Comment.$.Message", "changed title");
        //    var result22 = cars.UpdateOne(filter255, incAge121);
        //    //---------------


        //    var filterbcca = Builders<Car>.Filter.Eq(x => x.Year, 2020);
        //    var incAge1 = Builders<Car>.Update.Rename(u => u.Model, "Modeli");
        //    var resulta = cars.UpdateMany(filterbcc, incAge1);

        //    var filterbcc1 = Builders<Car>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
        //    var incAge11 = Builders<Car>.Update.Inc(u => u.Brand, 15); //brand üzerine +15 yapar
        //    //var incAge11 = Builders<Car>.Update.Unset(x => x.Model); //alını siler
        //    //var incAge11 = Builders<Car>.Update.Rename(u => u.Model, "Modeli");
        //    //var incAge11 = Builders<Car>.Update.Inc(u => u.Brand, 15).Set(x => x.Model, "51").Unset(x => x.Model);
        //    var result11 = cars.UpdateOne(filterbcc, incAge11);

        //    //var filterbcc = Builders<Car>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
        //    //var incAge = Builders<Car>.Update.Inc(u => u.Brand, 15); //brand üzerine +15 yapar
        //    //var incAge = Builders<Car>.Update.Unset(x => x.Model); //alını siler
        //    //var incAge = Builders<Car>.Update.Rename(u => u.Model, "Modeli");
        //    //var incAge = Builders<Car>.Update.Inc(u => u.Brand, 15).Set(x => x.Model, "51").Unset(x => x.Model);
        //    //var incAge = Builders<Car>.Update.CurrentDate(x => x.Model);
        //    //var incAge = Builders<Car>.Update.Min(u => u.Brand, 18); // Brand Alanı 18 büyük olanları 18 olarak yap
        //    //var incAge = Builders<Car>.Update.Max(u => u.Brand, 18);
        //    //var incAge = Builders<Car>.Update.SetOnInsert(u => u.Brand, 18);
        //    //var result = cars.UpdateOne(filterbcc, incAge);

        //    //var update = new UpdateDefinitionBuilder<Product>().Mul<Double>(r => r.Price, 1.1);
        //    //await products.UpdateManyAsync(filter, update); //,options);



        //    // Delete
        //    var vv = cars.DeleteOne(x => x.Id == "5e7abdda0f04b631c8bed741");
        //    var vv2 = cars.DeleteMany(x => x.Id == "5e7abdda0f04b631c8bed741");
        //    var vv3 = cars.FindOneAndDelete(x => x.Id == "5e7abdda0f04b631c8bed741");

        //    var deleteFilter = Builders<Car>.Filter.Eq(x => x.Id, "5e79dd10f8125027bc5871ac");
        //    var vv4 = cars.DeleteOne(deleteFilter);


        //    //using (var session = await client.StartSessionAsync())
        //    //{
        //    //    // Begin transaction
        //    //    session.StartTransaction();

        //    //    try
        //    //    {
        //    //        // Create some sample data
        //    //        var tv = new Product
        //    //        {
        //    //            Description = "Television",
        //    //            SKU = 4001,
        //    //            Price = 2000
        //    //        };
        //    //        var book = new Product
        //    //        {
        //    //            Description = "A funny book",
        //    //            SKU = 43221,
        //    //            Price = 19.99
        //    //        };
        //    //        var dogBowl = new Product
        //    //        {
        //    //            Description = "Bowl for Fido",
        //    //            SKU = 123,
        //    //            Price = 40.00
        //    //        };

        //    //        // Insert the sample data
        //    //        await products.InsertOneAsync(session, tv);
        //    //        await products.InsertOneAsync(session, book);
        //    //        await products.InsertOneAsync(session, dogBowl);

        //    //        var resultsBeforeUpdates = await products
        //    //                        .Find<Product>(session, Builders<Product>.Filter.Empty)
        //    //                        .ToListAsync();
        //    //        Console.WriteLine("Original Prices:\n");
        //    //        foreach (Product d in resultsBeforeUpdates)
        //    //        {
        //    //            Console.WriteLine(
        //    //                        String.Format("Product Name: {0}\tPrice: {1:0.00}",
        //    //                            d.Description, d.Price)
        //    //            );
        //    //        }

        //    //        // Increase all the prices by 10% for all products
        //    //        var update = new UpdateDefinitionBuilder<Product>()
        //    //                .Mul<Double>(r => r.Price, 1.1);
        //    //        await products.UpdateManyAsync(session,
        //    //                Builders<Product>.Filter.Empty,
        //    //                update); //,options);

        //    //        // Made it here without error? Let's commit the transaction
        //    //        await session.CommitTransactionAsync();
        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        Console.WriteLine("Error writing to MongoDB: " + e.Message);
        //    //        await session.AbortTransactionAsync();
        //    //        return false;
        //    //    }

        //    //}

        //}

        //public List<Car> Get()
        //{

        //    var builder = Builders<Car>.Filter;
        //    //var fieldExists = builder.Exists(x => x.Comment, true);
        //    var cursorbww = cars.Find(x => x.Brand == 45).Any();


        //    int[] dts = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //    var filterBuilder = Builders<Car>.Filter;
        //    var filterb = filterBuilder.In(x => x.Brand, dts) & filterBuilder.Lte("i", 100);
        //    var cursorb = cars.Find(filterb).ToCursor();

        //    //var update = new UpdateDefinitionBuilder<Product>().Mul<Double>(r => r.Price, 1.1);
        //    //await products.UpdateManyAsync(filter, update); //,options);

        //    var id = "a";

        //    var client = new MongoClient("mongodb://localhost:27017");
        //    using (var session = client.StartSession())
        //    {
        //        // Begin transaction
        //        session.StartTransaction();

        //        try
        //        {
        //            var dt1 = new List<Car>
        //        {
        //            new Car { CarID=Random(), Brand=3, Model="2012", Price=12, Year=2020, ImageUrl="deneme.jpg"},
        //            new Car {CarID=Random(), Brand=3, Model="2013", Price=13, Year=2025, ImageUrl="5deneme.jpg"}
        //        };
        //            cars.InsertMany(session, dt1);
        //            var a = 1 + Convert.ToInt32(id);
        //            session.CommitTransaction();
        //        }
        //        catch (Exception e)
        //        {
        //            session.AbortTransaction();
        //        }
        //    }
        //    string cdd = "";


        //    ////https://mongodb.github.io/mongo-csharp-driver/2.7/reference/driver/expressions/#in
        //    ////https://mongodb.github.io/mongo-csharp-driver/2.7/reference/driver/crud/linq/
        //    ////https://mongodb.github.io/mongo-csharp-driver/2.7/reference/driver/definitions/
        //    ////https://code.tutsplus.com/tutorials/full-text-search-in-mongodb--cms-24835
        //    ////https://www.codeproject.com/Tips/1103809/MongoDb-Csharp-MongoClient-x-TextResearch-How-To-D
        //    ////https://mongodb.github.io/mongo-csharp-driver/2.5/getting_started/quick_tour/
        //    ////https://mongodb.github.io/mongo-csharp-driver/2.5/getting_started/admin_quick_tour/
        //    ////https://gist.github.com/a3dho3yn/91dcc7e6f606eaefaf045fc193d3dcc3
        //    ////https://gist.github.com/a3dho3yn/91dcc7e6f606eaefaf045fc193d3dcc3
        //    ////https://developer.mongodb.com/how-to/transactions-c-dotnet
        //    ///*
        //    // * 
        //    // * db.articles.aggregate(
        //    //   [
        //    //     { $match: { $text: { $search: "cake tea" } } },
        //    //     { $sort: { score: { $meta: "textScore" } } },
        //    //     { $project: { title: 1, _id: 0 } }
        //    //   ]
        //    //)


        //    //db.stores.find(
        //    //   { $text: { $search: "coffee shop cake" } },
        //    //   { score: { $meta: "textScore" } }
        //    //).sort( { score: { $meta: "textScore" } } )


        //    //// insert some documents
        //    //await collection.InsertManyAsync(new []
        //    //{
        //    //    new BsonDocument("_id", 0).Add("content", "textual content"),
        //    //    new BsonDocument("_id", 1).Add("content", "additional content"),
        //    //    new BsonDocument("_id", 2).Add("content", "irrelevant content"),
        //    //});

        //    //var projection = Builders<Widget>.Projection.Expression(x => new { X = x.X, Y = x.Y });

        //    //var projection = Builders<Widget>.Projection.Expression(x => new { Sum = x.X + x.Y });

        //    //var projection = Builders<Widget>.Projection.Expression(x => new { Avg = (x.X + x.Y) / 2 });

        //    //var projection = Builders<Widget>.Projection.Expression(x => (x.X + x.Y) / 2);
        //    //*/

        //    ///*
        //    //var builder = Builders<BsonDocument>.Update;
        //    //var update = builder.Set("x", 1).Set("y", 3).Inc("z", 1);
        //    //*/

        //    ////----------------------------------------
        //    ////----------------------------------------
        //    ////----------------------------------------
        //    //var carProjection = Builders<Car>.Projection.Expression(x => new CarTestDTO { Brand = x.Brand, Model = x.Model });
        //    //var b1 = cars.Find(_ => true).Project(carProjection).ToList();

        //    //var carDTO = Builders<Car>.Projection.Include(x => x.Price).Include(x => x.Model).Exclude(x => x.Id);
        //    //var b2 = cars.Find(_ => true).Project(carDTO).ToList();

        //    //var queryBuild = Builders<Car>.Filter;
        //    //var queryFilter = queryBuild.Eq(x => x.Brand, 1) & queryBuild.Lt(x => x.Year, 20);
        //    //var b3 = cars.Find(queryFilter).ToList();

        //    //var b4 = cars.Find(x => x.Brand == 1).ToList();

        //    //var sortBuilder = Builders<Car>.Sort;
        //    //var sort = sortBuilder.Ascending(x => x.Brand).Descending(x => x.Price);
        //    //var b5 = cars.Find(_ => true).Sort(sort).ToList();

        //    //var indexKeysBuilder = Builders<Car>.IndexKeys;
        //    //var keys = indexKeysBuilder.Ascending(x => x.Brand).Descending(x => x.Price);
        //    //var b6 = cars.Indexes.CreateOne(keys, new CreateIndexOptions { Unique = true });

        //    //int[] localAges = new[] { 1, 20, 30 };
        //    //var b7 = cars.Find(p => localAges.Contains(p.Brand)).ToList();

        //    //var b8 = cars.Find(_ => true).Limit(1).ToList();

        //    //var b9 = cars.Find(_ => true).Skip(1).ToList();

        //    ////cars.messages.dropIndex("subject_text")
        //    ////db.messages.createIndex({ "subject":"text","content":"text"})
        //    ////db.haber.createIndex( { icerik: "text"}, { name: "icerik_text_index"} )
        //    ////cars.Indexes.CreateOne(Builders<Car>.IndexKeys.Text(x => x.Model), new CreateIndexOptions { Unique = true });
        //    //cars.Indexes.CreateOne(Builders<Car>.IndexKeys.Text(x => x.Model));
        //    ////var filterText = cars.Find(Builders<Car>.Filter.Text("2", "english"));
        //    //var filterText = cars.Find(Builders<Car>.Filter.Text("2"));
        //    //var b10 = filterText.ToList();


        //    //var projection1 = Builders<Car>.Projection.MetaTextScore("score");
        //    //var doc1 = cars.Find(_ => true).Project(projection1).First();


        //    //var eyp = cars.Count(_ => true);


        //    //var cursor = cars.Find(Builders<Car>.Filter.Text("Model"));
        //    //var results = cursor.ToList();

        //    //var baa1 = cars.AsQueryable().WhereText("2").Take(10).ToArray();

        //    //var subFilter = Builders<Car>.Filter.Eq("Model", "2");
        //    //var filter = Builders<Car>.Filter.ElemMatch("Model", subFilter);
        //    //var doc32 = cars.Find(filter).ToList();

        //    ////var projection = Builders<Car>.Projection.MetaTextScore("score");
        //    ////var doc2 = cars.Find(_ => true).Project(projection).First();
        //    //var sortMeta = Builders<Car>.Sort.MetaTextScore("score");
        //    //var doc2 = cars.Find(_ => true).Sort(sortMeta);

        //    //// Multple Qurey

        //    //var filterBuilder = Builders<Car>.Filter;
        //    //var filterb = filterBuilder.Gt("i", 50) & filterBuilder.Lte("i", 100);
        //    //var cursorb = cars.Find(filterb).ToCursor();

        //    ////----------------------------------------
        //    ////----------------------------------------
        //    ////----------------------------------------

        //    //({ "_id" : ObjectId("5e7abe0f6d3387085c46a97e") })
        //    var filterbcss = Builders<Car>.Filter.Eq("_id", ObjectId.Parse("5e7abe0f6d3387085c46a97e"));
        //    var cccc = cars.Find(filterbcss).FirstOrDefault();

        //    //var a1 = cars.Find(_ => true).Project("{Model:1,_id: 0}").ToList();
        //    //var a2 = cars.Find(FilterDefinition<Car>.Empty).Project(x => new  { x.Brand, x.Model }).ToList();
        //    //var a3 = cars.Find(new BsonDocument()).Project(x => new CarTestDTO { Brand = x.Brand, Model = x.Model }).SortBy(x => x.Model).ToList();
        //    //var a4 = cars.Find(new BsonDocument()).Project(x => new { x.Brand, x.Model }).ToList();

        //    //var a5 = cars.Aggregate().Lookup<Car, Marka, RootObject>(markalar, x => x.Brand, y => y.brandid, y => y.Markalar).ToList();
        //    //var a6 = cars.Aggregate().Match(x => x.Brand == 2).Lookup<Car, Marka, RootObject>(markalar, x => x.Brand, y => y.brandid, y => y.Markalar).ToList();

        //    //var a7 = cars.Aggregate().Lookup("Markalar", "Brand", "brandid", "Markalar").ToList();
        //    //List<RootObject> dd = BsonSerializer.Deserialize<List<RootObject>>(a7.ToJson());

        //    //var a8 = markalar.AsQueryable().Where(x => x.brandid == 1);
        //    //var a9 = cars.AsQueryable().Select(x => new Car { Brand = x.Brand });

        //    ////--1
        //    //var query = from c in cars.AsQueryable()
        //    //            join m in markalar.AsQueryable() on
        //    //     c.Brand equals m.brandid into j
        //    //            select new { c, j };
        //    //foreach (var item in query.ToList())
        //    //{
        //    //    foreach (var item2 in item.j)
        //    //    {

        //    //    }
        //    //}

        //    ////--2
        //    //var list = cars.Find(FilterDefinition<Car>.Empty).Project(Builders<Car>.Projection.Include("Price").Exclude("_id")).ToList();
        //    //foreach (var doc in list)
        //    //{
        //    //    Console.WriteLine(doc);
        //    //}

        //    ////--3
        //    //ProjectionDefinition<Car, CarTestDTO> ss = new FindExpressionProjectionDefinition<Car,CarTestDTO>(p => new CarTestDTO
        //    //{
        //    //     Brand= p.Brand,
        //    //     Model = p.Model
        //    //});
        //    //var modelas = cars.Find(new BsonDocument()).Project(ss).ToList();

        //    //------------------------------------------

        //    //Kendi içinde ilişkili arama
        //    var buildersss = Builders<Car>.Filter;
        //    var accountFilter = buildersss.ElemMatch(u => u.Comment, acc => acc.Name == "Zümra");
        //    var b21 = cars.Find(accountFilter).ToList();
        //    //----

        //    var filter = Builders<Car>.Filter.Eq(x => x.Model, "1");
        //    filter = filter & (Builders<Car>.Filter.Eq(x => x.Brand, 2) | Builders<Car>.Filter.Eq(x => x.Year, 5));
        //    //----

        //    var builder1 = Builders<Car>.Filter;
        //    var idListFilter = builder1.In(u => u.Brand, new[] { 3, 10, 14 });
        //    var b211 = cars.Find(idListFilter).ToList();

        //    var sortm = Builders<Car>.Sort.Ascending(u => u.Brand).Descending(u => u.CarID);
        //    var cursormm = cars.Find(x => x.CarID > 0).Sort(sortm).Skip(1).Limit(10).ToList();

        //    var highExamScoreFilter = Builders<BsonDocument>.Filter
        //       .ElemMatch<BsonValue>("scores",
        //       new BsonDocument { { "type", "exam" },
        //            { "score", new BsonDocument { { "$gte", 95 } } }
        //       });

        //    return cars.Find(car => true).ToList();
        //}

        //public string Pretty(object obj)
        //{
        //    return obj.ToJson(new JsonWriterSettings { Indent = true });
        //}

      

        //public class RootObject
        //{

        //    [BsonId]
        //    [BsonRepresentation(BsonType.ObjectId)]
        //    public string Id { get; set; }

        //    [BsonElement("Brand")]

        //    public int Brand { get; set; }

        //    [BsonElement("Model")]

        //    public string Model { get; set; }

        //    [BsonElement("Year")]

        //    public int Year { get; set; }

        //    [BsonElement("Price")]
        //    public decimal Price { get; set; }

        //    [BsonElement("ImageUrl")]
        //    public string ImageUrl { get; set; }


        //    public IEnumerable<Markalarn> Markalar { get; set; }
        //}



        //public class Markalarn
        //{
        //    [BsonId]
        //    [BsonRepresentation(BsonType.ObjectId)]
        //    public ObjectId ID { get; set; }

        //    public int brandid { get; set; }

        //    public string name { get; set; }
        //}

        //public long Random()
        //{ return Convert.ToInt64(DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Millisecond); }
    }

}
