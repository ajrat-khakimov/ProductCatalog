namespace ProductCatalog.Web.Extensions
{
	using AutoMapper;
	using Microsoft.Extensions.DependencyInjection;
	using ProductCatalog.AutoMapperProfiles;

	internal static class RegisterMapperExtension
	{
		public static IServiceCollection RegisterMapper(
			this IServiceCollection services) =>
			services.AddSingleton(new MapperConfiguration(ConfigureMapper).CreateMapper());

		private static void ConfigureMapper(IMapperConfigurationExpression expression)
		{
			expression.AddProfile<CreateProductHandlerProfile>();
		}
	}
}
