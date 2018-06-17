using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Core.Domain;
using MyStore.Core.Repositories;

namespace MyStore.Infrastructure.EF
{
    public class EfProductRepository : IProductRepository
    {
        private readonly MyStoreContext _context;

        public EfProductRepository(MyStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(Guid id)
            => await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Product>> BrowseAsync(string name = "")
            => await _context.Products
                .Where(x => x.Name.Contains(name ?? string.Empty))
                .ToListAsync();
            
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}