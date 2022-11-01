using Inventory.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Inventory.API.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IDistributedCache _redisCache;

        public InventoryRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task Delete(string name)
        {
            await _redisCache.RemoveAsync(name);
        }

        public async Task<Warehouse> Get(string name)
        {
            var warehouse = await _redisCache.GetStringAsync(name);

            if (String.IsNullOrEmpty(warehouse)) return null;

            return JsonConvert.DeserializeObject<Warehouse>(warehouse);
        }

        public async Task<Warehouse> Update(Warehouse warehouse)
        {
            await _redisCache.SetStringAsync(warehouse.Name, JsonConvert.SerializeObject(warehouse));

            return await Get(warehouse.Name);
        }
    }
}
