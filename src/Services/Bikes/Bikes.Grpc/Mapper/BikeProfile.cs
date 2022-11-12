using AutoMapper;
using Bikes.Grpc.Entities;
using Bikes.Grpc.Protos;

namespace Bikes.Grpc.Mapper
{
    public class BikeProfile : Profile
    {
        public BikeProfile()
        {
            CreateMap<Bike, BikeModel>().ReverseMap();
        }
    }
}
