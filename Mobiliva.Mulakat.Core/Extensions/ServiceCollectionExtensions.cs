namespace Mobiliva.Mulakat.Core.Extensions
{
    /// <Özet>
    /// ICoreModule ın program başlatılırken çalışmasını sağlayan yapı
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (ICoreModule module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}