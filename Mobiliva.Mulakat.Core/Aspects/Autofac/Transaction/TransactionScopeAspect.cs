
namespace Core.Aspects.Autofac.Transaction
{
	/// <ÖZET>
	/// Eğer Kodda hata olursa yapılan işlemi geri almayı sağlar.
	/// </summary>
    public class TransactionScopeAspect : MethodInterception
	{
		public override void Intercept(IInvocation invocation)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				try
				{
					invocation.Proceed();
					transactionScope.Complete();
				}
				catch (Exception e)
				{
					transactionScope.Dispose();
					throw e;
				}
			}
		}
	}
}