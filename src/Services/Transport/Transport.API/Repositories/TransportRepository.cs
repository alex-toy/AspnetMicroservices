using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Transport.API.Entities;

namespace Transport.API.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly IDistributedCache _redisCache;

        public TransportRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task Delete(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<TransportPlanning> Get(string userName)
        {
            var transportPlanning = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(transportPlanning)) return null;

            return JsonConvert.DeserializeObject<TransportPlanning>(transportPlanning);
        }

        public async Task<TransportPlanning> Update(TransportPlanning transportPlanning)
        {
            await _redisCache.SetStringAsync(transportPlanning.UserName, JsonConvert.SerializeObject(transportPlanning));

            return await Get(transportPlanning.UserName);
        }

        public async Task<TransportPlanning> Create(TransportPlanning transportPlanning)
        {
            await _redisCache.SetStringAsync(transportPlanning.UserName, JsonConvert.SerializeObject(transportPlanning));

            return await Get(transportPlanning.UserName);
        }
    }
}
