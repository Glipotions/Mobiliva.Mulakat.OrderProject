namespace Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching
{
    /// <ÖZET>
    /// Cachelemede kullanılması gereken methodların tutulduğu interface.
    /// </summary>
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        T Get<T>(string key);
        object Get(string key);
        //byte[] Gett(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }

    public interface ICacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class;
        T GetOrAdd<T>(string key, Func<T> action) where T : class;
        Task Clear(string key);
        void ClearAll();
    }
}