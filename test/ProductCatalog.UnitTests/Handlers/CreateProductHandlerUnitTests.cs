namespace ProductCatalog.UnitTests.Handlers
{
	using System.Threading;
	using System.Threading.Tasks;
	using AutoFixture;
	using AutoFixture.AutoNSubstitute;
	using AutoMapper;
	using NSubstitute;
	using ProductCatalog.Abstrations;
	using ProductCatalog.Contracts;
	using ProductCatalog.Entities;
	using ProductCatalog.Handlers.CreateProduct;
	using Xunit;

	public class CreateProductHandlerUnitTests
	{
		private const int Once = 1;

		public CreateProductHandlerUnitTests()
		{
			Fixture = MakeFixture();
		}

		private IFixture Fixture { get; }

		[Fact]
		public async Task Handle_GoodArguments_AllServicesCalled()
		{
			var productRepository = Fixture.Freeze<IProductRepository>();
			var mapper = Fixture.Freeze<IMapper>();

			var handler = Fixture.Create<CreateProductHandler>();
			var request = Fixture.Create<CreateProductRequest>();
			var cancellationToken = Fixture.Create<CancellationToken>();

			await handler.Handle(request, cancellationToken).ConfigureAwait(false);

			await productRepository.Received(Once)
				.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
				.ConfigureAwait(false);

			mapper.Received(Once).Map<Product>(Arg.Any<object>());
			mapper.Received(Once).Map<ProductDto>(Arg.Any<object>());
		}

		private static IFixture MakeFixture() =>
			new Fixture().Customize(new AutoNSubstituteCustomization());
	}
}
