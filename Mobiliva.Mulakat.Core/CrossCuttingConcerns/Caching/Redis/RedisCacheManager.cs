//using Microsoft.Extensions.Configuration;
//using ServiceStack.Redis;
//using System;

//namespace Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching.Redis
//{
//    /// <ÖZET>
//    /// Cacheleme yöntemlerinden Redis'i kullanmak için yapılan manager.
//    /// </summary>
//    public class RedisCacheManager : ICacheManager
//    {
//        private readonly RedisModel _redisModel;
//        private readonly RedisEndpoint _redisEndpoint;
//        public IConfiguration Configuration;


//        private void RedisInvoker(Action<RedisClient> redisAction)
//        {
//            using (var client = new RedisClient(_redisEndpoint))
//            {
//                redisAction.Invoke(client);
//            }
//        }

//        private readonly RedisClient _redisClient;

//        public RedisCacheManager(RedisClient redisServer)
//        {
//            this._redisClient = redisServer;
//        }

//        //public RedisCacheManager()
//        //{
//        //    _redisEndpoint = new RedisEndpoint("localhost", 6379);
//        //}

//        public RedisCacheManager(IConfiguration Configuration)
//        {
//            _redisModel = Configuration.GetSection("Redis").Get<RedisModel>();
//            _redisEndpoint = new RedisEndpoint(host: _redisModel.Host, port: _redisModel.Port, db: _redisModel.Db);
//        }

//        public T Get<T>(string key)
//        {
//            var result = default(T);
//            RedisInvoker(x => { result = x.Get<T>(key); });
//            return result;
//        }

//        public object Get(string key)
//        {
//            var result = default(object);
//            RedisInvoker(x => { result = x.Get<object>(key); });
//            //var jsonResult = JsonConvert.DeserializeObject(result);
//            return result;
//        }
//        public byte[] Gett(string key)
//        {
//            throw new NotImplementedException();
//        }

//        public void Add(string key, object data, int duration)
//        {
//            RedisInvoker(x => x.Add(key, data, TimeSpan.FromMinutes(duration)));
//        }

//        public void Add(string key, object data)
//        {
//            RedisInvoker(x => x.Add(key, data));
//        }

//        public bool IsAdd(string key)
//        {
//            var isAdded = false;
//            RedisInvoker(x => isAdded = x.ContainsKey(key));
//            return isAdded;
//        }

//        public void Remove(string key)
//        {
//            RedisInvoker(x => x.Remove(key));
//        }

//        public void RemoveByPattern(string pattern)
//        {
//            RedisInvoker(x => x.RemoveByPattern(pattern));
//        }

//        public void Clear()
//        {
//            RedisInvoker(x => x.FlushAll());
//        }


//    }
//}