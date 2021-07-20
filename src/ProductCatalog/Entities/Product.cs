namespace ProductCatalog.Entities
{
	using ProductCatalog.Abstractions;

	internal sealed class Product : EntityBase
	{
		public string Name { get; set; }

		public decimal Amount { get; set; }
	}
}
