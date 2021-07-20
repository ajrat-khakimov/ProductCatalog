namespace ProductCatalog.Storage.Sqlite
{
	using Microsoft.EntityFrameworkCore;
	using ProductCatalog.Entities;
	using ProductCatalog.Storage.Sqlite.Configurations;

	internal sealed class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) :
			base(options)
		{
		}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new ProductConfiguration());
		}
	}
}
