using Marten.Schema;

namespace Catalog.API.Data
{
	public class CatalogInitialData : IInitialData
	{
		public async Task Populate(IDocumentStore store, CancellationToken cancellation)
		{
			using var session = store.LightweightSession();

			if (await session.Query<Product>().AnyAsync())
			{
				return;
			}

			session.Store<Product>(GetPreconfiguredProducts());
			await session.SaveChangesAsync(cancellation);
		}

		private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
		{
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Product 1",
				Description = "Description 1",
				Price = 100,
				ImageFile = "product1.png",
				Category = new List<string>{ "Category 1" }
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Product 2",
				Description = "Description 2",
				Price = 200,
				ImageFile = "product2.png",
					Category = new List<string>{ "Category 1" }
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Product 3",
				Description = "Description 3",
				Price = 300,
				ImageFile = "product3.png",
				Category = new List<string>{ "Category 1" }
			}
		};
	}
}
