namespace ProductCatalog.Web
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Design;
	using Microsoft.Extensions.Configuration;
	using ProductCatalog.Storage.Sqlite;

	internal sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlite("FileName=products.db");

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}