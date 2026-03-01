using Microsoft.Extensions.Caching.Distributed;
namespace StageWise.Services.Infrastructure.Implementations
{

    public class RedisService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value);
        }

        public async Task<string?> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}