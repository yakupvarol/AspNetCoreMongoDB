using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Entities
{
    public class Markalar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CarID")]
        public Int64 CarID { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("brandid")]
        public Int64 brandid { get; set; }
    }
}
