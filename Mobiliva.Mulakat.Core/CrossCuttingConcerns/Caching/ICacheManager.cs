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
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}