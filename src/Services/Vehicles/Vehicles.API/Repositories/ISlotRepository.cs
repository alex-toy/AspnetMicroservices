using Vehicles.API.Entities;

namespace Vehicles.API
{
    public interface ISlotRepository
    {
        Task<TruckSlot> Get(string truckId);
        Task<IEnumerable<TruckSlot>> GetAll();
        Task<bool> Create(TruckSlot truckSlot);
        Task<bool> Update(TruckSlot truckSlot);
        Task<bool> Delete(string truckId);
    }
}
