namespace ProductCatalog.Controllers.Api
{
	using System.Threading;
	using System.Threading.Tasks;
	using Ardalis.GuardClauses;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using ProductCatalog.Contracts;
	using ProductCatalog.Handlers.CreateProduct;

	[Route("api/[controller]")]
	public sealed class ProductsController : ControllerBase
	{
		public ProductsController(IMediator mediator)
		{
			Mediator = Guard.Against.Null(mediator, nameof(mediator));
		}

		private IMediator Mediator { get; }

		[HttpPost]
		public async Task<IActionResult> CreateProductAsync(
			[FromBody] ProductDto productDto,
			CancellationToken cancellationToken = default)
		{
			var request = new CreateProductRequest(productDto);
			var response = await Mediator.Send(request, cancellationToken).ConfigureAwait(false);

			return Created(string.Empty, response.Payload);
		}
	}
}
