using Microsoft.Extensions.Caching.Distributed;
namespace MultiShop.WebUI.Services
{
    public class RedisTokenCacheHelper
    {
        private readonly IDistributedCache _cache;

        public RedisTokenCacheHelper(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetOrAddAsync(string key, Func<Task<(string token, int expiresInSeconds)>> factory)
        {
            var cachedToken = await _cache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(cachedToken))
                return cachedToken;

            var (token, expiresInSeconds) = await factory();

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Math.Max(expiresInSeconds - 30, 5))
            };

            await _cache.SetStringAsync(key, token, options);
            return token;
        }
    }
}
