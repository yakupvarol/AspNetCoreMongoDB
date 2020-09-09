using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.DTO.Car
{
    public class CarListRequestDTO
    {
        public string Id { get; set; }
        public Int64 CarID { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
        public int[] BrandArray { get; set; }
        public string CommentName { get; set; }
        public string TextData { get; set; }
    }
}
