using System;

namespace AspNetCoreMongoDB.DTO.Car
{
    public class CarListResponseDTO
    {
        public Int64 CarID { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Test { get; set; }
    }
}
