namespace ProductCatalog.Web
{
	using Abdt.ConsumerLoan.Adapter.SiebelCrm.Controllers;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using ProductCatalog.Extensions;
	using ProductCatalog.Storage.Sqlite.Extensions;
	using ProductCatalog.Web.Extensions;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().RegisterApi();
			services.RegisterDomainServices();
			services.RegisterMapper();
			services.RegisterProductRepository(Configuration);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
