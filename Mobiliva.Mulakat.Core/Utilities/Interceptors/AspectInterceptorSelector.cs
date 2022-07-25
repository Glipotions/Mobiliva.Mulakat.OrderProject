using Mobiliva.Mulakat.Core.Aspects.Autofac.Exception;
using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace Mobiliva.Mulakat.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //-> Bu Kod tüm loglama işlemlerini aktif eder

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
