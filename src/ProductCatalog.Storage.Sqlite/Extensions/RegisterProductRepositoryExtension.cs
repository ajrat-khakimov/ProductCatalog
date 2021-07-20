namespace ProductCatalog.Storage.Sqlite.Extensions
{
	using Ardalis.GuardClauses;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using ProductCatalog.Abstrations;
	using ProductCatalog.Storage.Sqlite;
	using ProductCatalog.Storage.Sqlite.Invariants;

	internal static class RegisterProductRepositoryExtension
	{
		public static IServiceCollection RegisterProductRepository(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			Guard.Against.Null(services, nameof(services));
			Guard.Against.Null(configuration, nameof(configuration));

			var connectionString = configuration
				.GetSection(RegisterProductRepositoryExtensionInvariants.ConnectionStringSectionPath)
				.Get<string>();

			return services
				.AddDbContextPool<AppDbContext>(options => options.UseSqlite(connectionString))
				.AddScoped<IProductRepository, SqlProductRepository>();
		}
	}
}
