using Deliveries.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Deliveries.API.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly IDistributedCache _redisCache;

        public DeliveryRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task Delete(string deliveryId)
        {
            await _redisCache.RemoveAsync(deliveryId);
        }

        public async Task<Delivery> Get(string deliveryId)
        {
            var basket = await _redisCache.GetStringAsync(deliveryId);

            if (String.IsNullOrEmpty(basket)) return null;

            return JsonConvert.DeserializeObject<Delivery>(basket);
        }

        public async Task<Delivery> Update(Delivery delivery)
        {
            await _redisCache.SetStringAsync(delivery.DeliveryId, JsonConvert.SerializeObject(delivery));

            return await Get(delivery.DeliveryId);
        }

        public async Task<Delivery> Create(Delivery delivery)
        {
            await _redisCache.SetStringAsync(delivery.DeliveryId, JsonConvert.SerializeObject(delivery));

            return await Get(delivery.DeliveryId);
        }
    }
}
