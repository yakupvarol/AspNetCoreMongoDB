using AspNetCoreMongoDB.DTO.Car;
using AspNetCoreMongoDB.Entities;
using AutoMapper;

namespace AspNetCoreMongoDB.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cars, CarListResponseDTO>();
        }
    }
}
