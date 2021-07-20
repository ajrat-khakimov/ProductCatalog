namespace ProductCatalog.Handlers.CreateProduct
{
	using MediatR;
	using ProductCatalog.Contracts;

	internal sealed class CreateProductRequest : IRequest<CreateProductResponse>
	{
		public CreateProductRequest(ProductDto payload) => Payload = payload;

		public ProductDto Payload { get; }
	}
}
