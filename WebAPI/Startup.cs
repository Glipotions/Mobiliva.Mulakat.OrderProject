using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mobiliva.Mulakat.Business;
using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Mobiliva.Mulakat.Core.DependencyResolver;
using Mobiliva.Mulakat.Core.Extensions;
using Mobiliva.Mulakat.Core.Utilities.IoC;
using Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq;

namespace WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//Autofac, Ninject, CastleWindsor, StructerMap,LightInject, DryInject --> IoC Container yokken alt yapý saðlar
			services.AddControllers();
			services.AddCors();
			services.AddAutoMapper(typeof(AutoMapperProfile));
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
			});

			services.AddDependencyResolvers(new ICoreModule[] {
			   new CoreModule()
			});

			services.AddTransient<FileLogger>();

			services.AddScoped<IMailSenderBackgroundService, MqQueueHelper>();
			services.AddScoped<IMessageConsumer, MqConsumerHelper>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
			}
			//app.ConfigureCustomExceptionMiddleware();

			app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
