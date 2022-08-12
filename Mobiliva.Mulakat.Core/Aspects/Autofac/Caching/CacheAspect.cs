using Microsoft.AspNetCore.Http;
using Mobiliva.Mulakat.Core.Utilities.Results;
using System.Text;

namespace Mobiliva.Mulakat.Core.Aspects.Autofac.Caching
{
    /// <ÖZET>
    /// Ön Bellekten veri almayı sağlayan yapı, istenilen süre belirtilir o süre boyunca veri cache de kalır.
    /// </summary>
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        /// <ÖZET>
        /// Intercept araya girme anlamı vardır.
        /// method namei alır örnek : Business.Concrete.OrderManager.GetAll
        /// arguments: GetAll() burada argümen yoktur, GetById(1), burada id argümen olmuş olur. bunu kontrol eder
        /// key: cache de key ile veri bilgisi tutulur, methodName ve varsa argüman sonuna eklenerek key oluşturulur.
        /// if bloğu içinde oluşturulan key ile alakalı veri zaten var mı kontrol edilir varsa direkt olarak o veri getirilir 
        ///     yoksa databaseden verilen key'in datası olarak eklenir.
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
