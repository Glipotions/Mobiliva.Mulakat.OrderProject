namespace Mobiliva.Mulakat.Core.Utilities.Interceptors
{
    /// <ÖZET>
    /// Aspects Klasöründeki Aspectlerin Attribute özelliği kazanmasını sağlayan yapının temelidir.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}