using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyStore.Services.Products.Commands;
using MyStore.Services.Products.Dto;
using MyStore.Services.Products.Queries;

namespace MyStore.Services.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetAsync(Guid id);
        Task<IEnumerable<ProductDto>> BrowseAsync(BrowseProducts query);
        Task AddAsync(CreateProduct command);
    }
}