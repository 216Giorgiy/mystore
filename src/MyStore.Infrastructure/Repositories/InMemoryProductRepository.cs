using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Core.Domain;
using MyStore.Core.Repositories;

namespace MyStore.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Iphone X", "phones", 4000),
            new Product(Guid.NewGuid(), "Samsung S8", "phones", 3500),
            new Product(Guid.NewGuid(), "Xbox 360", "pc", 2000)
        };

        public async Task<Product> GetAsync(Guid id)
            => await Task.FromResult(_products.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Product>> BrowseAsync(string name = "")
            => await Task.FromResult(_products.Where(x => x.Name.Contains(name ?? string.Empty)));

        public async Task AddAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
    }
}