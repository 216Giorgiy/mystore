using System;
using Newtonsoft.Json;

namespace MyStore.Services.Products.Commands
{
    public class CreateProduct
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
        public decimal Price { get; }

        [JsonConstructor]
        public CreateProduct(Guid id, string name, 
            string category, decimal price)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Category = category;
            Price = price;
        }
    }
}