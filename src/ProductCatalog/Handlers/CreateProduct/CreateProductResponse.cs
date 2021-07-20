namespace ProductCatalog.Handlers.CreateProduct
{
	using ProductCatalog.Contracts;

	internal sealed class CreateProductResponse
	{
		public CreateProductResponse(ProductDto payload) => Payload = payload;

		public ProductDto Payload { get; }
	}
}
