using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ControlGo.Infrastructure.Cache
{
    public class CacheService
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;

        public CacheService(IDistributedCache cache, IConfiguration configuration)
        {            
            _cache = cache;
            _configuration = configuration;
        }
        public async Task<string> GetOrSetDataFromCache(string cacheKey, Func<Task<string>> getDataFunction, int cacheDurationInHour = 1)
        {
            var cachedData = await _cache.GetStringAsync(cacheKey);

            if (cachedData != null)
            {
                // Si los datos están en caché, devuélvelos
                return cachedData;
            }

            // Si no hay datos en caché, llama a la función para obtenerlos
            var newData = await getDataFunction();

            // Guarda los nuevos datos en caché por un tiempo determinado (por ejemplo, 1 hora)
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(cacheDurationInHour)
            };

            await _cache.SetStringAsync(cacheKey, newData, cacheOptions);

            return newData;
        }

        public async Task<T?> GetAsync<T>(string cacheKey)
        {
            var cached = await _cache.GetAsync(cacheKey);
            if (cached == null || cached?.Length == 0)
                return default;

            return cached != null ? (T?)await JsonSerializer.DeserializeAsync(new MemoryStream(cached), typeof(T)) : default;
        }


        public async Task SetAsync<T>(string cacheKey, T value)
        {
            var dataSerializer = await Task.Run(() => JsonSerializer.SerializeToUtf8Bytes(value));
            var cacheDuration = _configuration.GetSection("CacheSettings:CacheDuration").Value ?? "00:30:00";
            await _cache.SetAsync(cacheKey, dataSerializer, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.Parse(cacheDuration) });
        }

        public async Task SetAsync<T>(string cacheKey, T value, string cacheDuration)
        {
            var dataSerializer = await Task.Run(() => JsonSerializer.SerializeToUtf8Bytes(value));            
            await _cache.SetAsync(cacheKey, dataSerializer, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.Parse(cacheDuration) });
        }
    }
}

