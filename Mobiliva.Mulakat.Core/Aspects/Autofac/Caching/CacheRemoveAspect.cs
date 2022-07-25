namespace Core.Aspects.Autofac.Caching
{
	/// <ÖZET>
	/// Cache yapısında veri değiştiyse önbellekteki veri yanlış olacağından veriyi önbellekten silmeye yarar.
	/// </summary>
    public class CacheRemoveAspect : MethodInterception
	{
		private string _pattern;
		private ICacheManager _cacheManager;

		public CacheRemoveAspect(string pattern)
		{
			_pattern = pattern;
			_cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
		}

		protected override void OnSuccess(IInvocation invocation)
		{
			_cacheManager.RemoveByPattern(_pattern);
		}
	}
}