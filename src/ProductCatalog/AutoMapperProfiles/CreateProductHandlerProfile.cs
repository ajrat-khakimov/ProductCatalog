namespace ProductCatalog.AutoMapperProfiles
{
	using AutoMapper;
	using ProductCatalog.Contracts;
	using ProductCatalog.Entities;

	internal sealed class CreateProductHandlerProfile : Profile
	{
		public CreateProductHandlerProfile()
		{
			CreateMap<ProductDto, Product>();
			CreateMap<Product, ProductDto>();
		}
	}
}
