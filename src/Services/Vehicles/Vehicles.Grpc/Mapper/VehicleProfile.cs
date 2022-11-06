using AutoMapper;
using Vehicles.Grpc.Entities;
using Vehicles.Grpc.Protos;

namespace Vehicles.Grpc.Mapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<TruckSlot, SlotModel>().ReverseMap();
        }
    }
}
