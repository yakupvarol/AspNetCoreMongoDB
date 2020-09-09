using AspNetCoreMongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AspNetCoreMongoDB.DTO.Car
{
    public class CarBrandRelationshipDTO
    {
        public class Car
        {

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("CarID")]
            public Int64 CarID { get; set; }


            [BsonElement("Brand")]
            public int Brand { get; set; }

            [BsonElement("Model")]

            public string Model { get; set; }

            [BsonElement("Year")]

            public int Year { get; set; }

            [BsonElement("Price")]
            public decimal Price { get; set; }

            [BsonElement("ImageUrl")]
            public string ImageUrl { get; set; }

            
            [BsonElement("lastModified")]
            public DateTime lastModified { get; set; }

            [BsonElement("Comment")]
            public ICollection<Comment> Comment { get; set; }
            public ICollection<Brand> Markalar { get; set; }
        }

        public class Brand
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }


            [BsonElement("CarID")]
            public Int64 CarID { get; set; }

            [BsonElement("brandid")]
            public int brandid { get; set; }

            [BsonElement("name")]
            public string name { get; set; }
        }
    }
}
