using Vehicles.Grpc.Entities;

namespace Vehicles.Grpc
{
    public interface ISlotRepository
    {
        Task<TruckSlot> Get(string truckId);
        Task<bool> Create(TruckSlot truckSlot);
        Task<bool> Update(TruckSlot truckSlot);
        Task<bool> Delete(string truckId);
    }
}
