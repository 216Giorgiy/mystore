using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Core.Domain;
using MyStore.Core.Repositories;
using MyStore.Services.Products.Commands;
using MyStore.Services.Products.Dto;
using MyStore.Services.Products.Queries;

namespace MyStore.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetAsync(Guid id)
            => await _productRepository.GetAsync(id)
                .ContinueWith(t => Map(t.Result));

        public async Task<IEnumerable<ProductDto>> BrowseAsync(BrowseProducts query)
            => await _productRepository.BrowseAsync(query.Name)
                .ContinueWith(t => t.Result.Select(Map));

        public async Task AddAsync(CreateProduct command)
            => await _productRepository.AddAsync(
                new Product(command.Id, command.Name,
                    command.Category, command.Price));

        private ProductDto Map(Product product)
            => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price
            };
    }
}