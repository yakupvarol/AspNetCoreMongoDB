using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMongoDB.Entities
{
    public class Cars 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CarID")]
        [Required]
        public Int64 CarID { get; set; }

        [BsonElement("Brand")]
        [Required]
        public int Brand { get; set; }

        [BsonElement("Model")]
        [Required]
        public string Model { get; set; }

        [BsonElement("Year")]
        [Required]
        public int Year { get; set; }

        [BsonElement("Price")]
        [Display(Name = "Price($)")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }

        [BsonElement("lastModified")]
        public DateTime lastModified { get; set; }

        [BsonElement("Comment")]
        public ICollection<Comment> Comment { get; set; }

        [BsonIgnore]
        public ICollection<Markalar> Markalar { get; set; }
    }
}
