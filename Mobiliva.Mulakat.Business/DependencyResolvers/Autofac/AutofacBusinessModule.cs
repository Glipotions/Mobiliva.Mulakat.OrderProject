using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Mobiliva.Mulakat.Business.Concrete;

namespace Mobiliva.Mulakat.Business.DependencyResolvers.Autofac
{
    /// <ÖZET>
    /// Database e Entitylerin dataAccessLayer ları ve Managerlerini kayıt ettirdiğimiz bölüm
    /// </summary>
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            //builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    //Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
