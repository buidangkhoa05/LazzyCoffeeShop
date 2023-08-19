
using Autofac.Extensions.DependencyInjection;
using Autofac;
using LazzyCoffeeShop.Web.Configuration;

namespace LazzyCoffeeShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Config Autofac
            builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            //Config Autofac Container
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterModule(new AutofacModule());
                container.RegisterServices();
            });

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "LazzyCoffeeShopAPI", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}