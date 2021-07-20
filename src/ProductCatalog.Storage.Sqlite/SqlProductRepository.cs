namespace ProductCatalog.Storage.Sqlite
{
	using System.Threading;
	using System.Threading.Tasks;
	using ProductCatalog.Abstrations;
	using ProductCatalog.Entities;

	internal sealed class SqlProductRepository : IProductRepository
	{
		public SqlProductRepository(AppDbContext context)
		{
			Context = context;
		}

		private AppDbContext Context { get; }

		public async Task<Product> CreateAsync(
			Product product,
			CancellationToken cancellationToken = default)
		{
			await Context.AddAsync(product, cancellationToken).ConfigureAwait(false);
			await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

			cancellationToken.ThrowIfCancellationRequested();

			return product;
		}
	}
}
