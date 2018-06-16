using AutoMapper;
using MyStore.Core.Domain;
using MyStore.Services.Products.Dto;

namespace MyStore.Services
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
            }).CreateMapper();
    }
}