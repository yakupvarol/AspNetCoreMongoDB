using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Entities
{
    [BsonIgnoreExtraElements]
    public class Comment
    {
        [BsonElement("CommentID")]
        public long CommentID { get; set; }

        [BsonElement("CarID")]
        public long CarID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }
    }
}
