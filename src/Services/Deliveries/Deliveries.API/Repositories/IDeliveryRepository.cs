using Deliveries.API.Entities;

namespace Deliveries.API.Repositories
{
    public interface IDeliveryRepository
    {
        Task<Delivery> Get(string deliveryId);
        Task<Delivery> Create(Delivery delivery);
        Task<Delivery> Update(Delivery delivery);
        Task Delete(string deliveryId);
    }
}
