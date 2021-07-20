namespace ProductCatalog.Abstrations
{
	using System.Threading;
	using System.Threading.Tasks;
	using ProductCatalog.Entities;

	internal interface IProductRepository
	{
		Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
	}
}
