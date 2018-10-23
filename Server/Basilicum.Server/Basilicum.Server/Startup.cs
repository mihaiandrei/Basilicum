namespace Basilicum.Server
{
    using AutoMapper;
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
	{
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
								.SetBasePath(env.ContentRootPath)
								.AddJsonFile("appsettings.json", true, true)
								.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
								.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
					.AddFeatureFolders();

			services.AddAutoMapper(typeof(Startup));

            services.AddMediatR(typeof(Startup));
			services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Basilicum", Version = "v1" });
				c.CustomSchemaIds(schema => schema.FullName);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMapper mapper)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basilicum");
			});

			app.UseMvc();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
	}
}
