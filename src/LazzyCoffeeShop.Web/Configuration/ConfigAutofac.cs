using LazzyCoffeeShop.Domain.Configuration;

namespace LazzyCoffeeShop.Web.Configuration
{
    public static class ConfigAutofac
    {
        public static void ConfigureAutofacContainer(this WebApplicationBuilder builder)
        {
            //Config Autofac
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            //Config Autofac Container
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterModule(new AutofacModule());
            });
        }
    }

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterServices();
            //Register Mapster
            builder.RegisterMapster();

            base.Load(builder);
        }
    }
}
