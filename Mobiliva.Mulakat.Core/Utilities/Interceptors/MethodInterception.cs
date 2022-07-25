namespace Mobiliva.Mulakat.Core.Utilities.Interceptors
{
    /// <ÖZET>
    /// Aspects Klasöründeki Aspectlerin Attribute özelliği kazanmasını sağlayan yapı kurulur.
    /// </summary>
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation :  business method
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }

}