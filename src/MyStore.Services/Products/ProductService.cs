using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetAsync(Guid id)
            => await _productRepository.GetAsync(id)
                .ContinueWith(t => _mapper.Map<ProductDto>(t.Result));

        public async Task<IEnumerable<ProductDto>> BrowseAsync(BrowseProducts query)
            => await _productRepository.BrowseAsync(query.Name)
                .ContinueWith(t => t.Result.Select(_mapper.Map<ProductDto>));

        public async Task AddAsync(CreateProduct command)
            => await _productRepository.AddAsync(
                new Product(command.Id, command.Name,
                    command.Category, command.Price));
    }
}