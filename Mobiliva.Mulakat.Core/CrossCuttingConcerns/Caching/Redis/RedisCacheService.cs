using StackExchange.Redis;
using System.Text.Json;

namespace Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching.Redis;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _cache;
    private TimeSpan ExpireTime => TimeSpan.FromDays(1);

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _cache = connectionMultiplexer.GetDatabase();
    }

    public async Task Clear(string key)
    {
        await _cache.KeyDeleteAsync(key);
    }

    public void ClearAll()
    {
        var endpoints = _connectionMultiplexer.GetEndPoints(true);
        foreach (var endpoint in endpoints)
        {
            var server = _connectionMultiplexer.GetServer(endpoint);
            server.FlushAllDatabases();
        }
    }

    public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class
    {
        var result = await _cache.StringGetAsync(key);
        if (result.IsNull)
        {
            result = JsonSerializer.SerializeToUtf8Bytes(await action());
            await SetValueAsync(key, result);
        }
        return JsonSerializer.Deserialize<T>(result);
    }

    public async Task<string> GetValueAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringGetAsync(key);
        //return await _cache.StringGetAsync(key);
    }

    public async Task<bool> SetValueAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringSetAsync(key, value);

        //return await _cache.StringSetAsync(key, value, ExpireTime);
    }

    //public T GetOrAdd<T>(string key, Func<T> action) where T : class
    public T GetOrAdd<T>(string key, Func<T> action) where T : class
    {
        var db = _connectionMultiplexer.GetDatabase();

        var result = db.StringGet(key);
        //var result = _cache.StringGet(key);
        if (result.IsNull)
        {
            result = JsonSerializer.SerializeToUtf8Bytes(action());
            _cache.StringSet(key, result, ExpireTime);
        }
        return JsonSerializer.Deserialize<T>(result);
    }
}