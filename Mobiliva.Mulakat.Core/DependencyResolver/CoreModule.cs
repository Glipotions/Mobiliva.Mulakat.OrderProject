using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching;
using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching.Microsoft;
using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching.Redis;
using Mobiliva.Mulakat.Core.Utilities.IoC;
using System.Diagnostics;

namespace Mobiliva.Mulakat.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            /// .Net Cache için alttaki ilk 2 satır aktifleştirilir 3.sü yorum satırına alınır. Redis için ise tam tersi.
            //serviceCollection.AddMemoryCache();
            //serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();

            /// Performans Aspect için gerekli kod
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}