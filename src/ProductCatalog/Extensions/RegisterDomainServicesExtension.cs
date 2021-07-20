namespace ProductCatalog.Extensions
{
	using Ardalis.GuardClauses;
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;

	internal static class RegisterDomainServicesExtension
	{
		public static IServiceCollection RegisterDomainServices(
			this IServiceCollection services)
		{
			Guard.Against.Null(services, nameof(services));

			return services.AddMediatR(typeof(RegisterDomainServicesExtension).Assembly);
		}
	}
}
