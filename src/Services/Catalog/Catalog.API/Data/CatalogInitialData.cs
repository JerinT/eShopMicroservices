

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
        {
            new Product
            {
                Id = new Guid("a2c3e4d5-f6b7-8c9d-0e1f-2a3b4c5d6e7f"),
                Name = "Product 1",
                Category = new List<string> { "Category A", "Category B" },
                Description = "Description for Product 1",
                ImageFile = "image1.jpg",
                Price = 29.99m
            },
            new Product
            {
                Id = new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2a3b4c5d6e7f"),
                Name = "Product 2",
                Category = new List<string> { "Category B" },
                Description = "Description for Product 2",
                ImageFile = "image2.jpg",
                Price = 49.99m
            },
            new Product
            {
                Id = new Guid("c2d3e4f5-a6b7-8c9d-0e1f-2a3b4c5d6e7f"),
                Name = "Product 3",
                Category = new List<string> { "Category C" },
                Description = "Description for Product 3",
                ImageFile = "image3.jpg",
                Price = 19.99m
            },
            new Product
            {
                Id = new Guid("d2e3f4a5-b6c7-8d9e-0f1a-2a3b4c5d6e7f"),
                Name = "Product 4",
                Category = new List<string> { "Category A", "Category C" },
                Description = "Description for Product 4",
                ImageFile = "image4.jpg",
                Price = 39.99m
            },
            new Product
            {
                Id = new Guid("e2f3a4b5-c6d7-8e9f-0a1b-2a3b4c5d6e7f"),
                Name = "Product 5",
                Category = new List<string> { "Category D" },
                Description = "Description for Product 5",
                ImageFile = "image5.jpg",
                Price = 59.99m
            },
            new Product
            {
                Id = new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2a3b4c5d6e7f"),
                Name = "Product 6",
                Category = new List<string> { "Category A" },
                Description = "Description for Product 6",
                ImageFile = "image6.jpg",
                Price = 24.99m
            },
            new Product
            {
                Id = new Guid("a3b4c5d6-e7f8-9a0b-1c2d-3a4b5c6d7e8f"),
                Name = "Product 7",
                Category = new List<string> { "Category B", "Category D" },
                Description = "Description for Product 7",
                ImageFile = "image7.jpg",
                Price = 34.99m
            },
            new Product
            {
                Id = new Guid("b3c4d5e6-f7a8-9b0c-1d2e-3a4b5c6d7e8f"),
                Name = "Product 8",
                Category = new List<string> { "Category C", "Category E" },
                Description = "Description for Product 8",
                ImageFile = "image8.jpg",
                Price = 44.99m
            },
            new Product
            {
                Id = new Guid("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"),
                Name = "Product 9",
                Category = new List<string> { "Category E" },
                Description = "Description for Product 9",
                ImageFile = "image9.jpg",
                Price = 54.99m
            },
            new Product
            {
                Id = new Guid("d3e4f5a6-b7c8-9d0e-1f2a-3a4b5c6d7e8f"),
                Name = "Product 10",
                Category = new List<string> { "Category A", "Category B", "Category C" },
                Description = "Description for Product 10",
                ImageFile = "image10.jpg",
                Price = 64.99m
            }
        };
        }
    }
}
