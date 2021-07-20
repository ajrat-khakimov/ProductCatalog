namespace ProductCatalog.Handlers.CreateProduct
{
	using System.Threading;
	using System.Threading.Tasks;
	using Ardalis.GuardClauses;
	using AutoMapper;
	using MediatR;
	using ProductCatalog.Abstrations;
	using ProductCatalog.Contracts;
	using ProductCatalog.Entities;

	internal sealed class CreateProductHandler :
		IRequestHandler<CreateProductRequest, CreateProductResponse>
	{
		public CreateProductHandler(
			IProductRepository productRepository,
			IMapper mapper)
		{
			ProductRepository = Guard.Against.Null(productRepository, nameof(productRepository));
			Mapper = Guard.Against.Null(mapper, nameof(mapper));
		}

		private IProductRepository ProductRepository { get; }

		private IMapper Mapper { get; }

		public async Task<CreateProductResponse> Handle(
			CreateProductRequest request,
			CancellationToken cancellationToken = default)
		{
			var product = await ProductRepository
				.CreateAsync(
					Mapper.Map<Product>(request.Payload),
					cancellationToken)
				.ConfigureAwait(false);

			return new CreateProductResponse(Mapper.Map<ProductDto>(product));
		}
	}
}
