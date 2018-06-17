using System;

namespace MyStore.Core.Domain
{

    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        private Product()
        {
        }

        public Product(Guid id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            SetPrice(price);
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Invalid price.", nameof(price)); 
            }

            Price = price;
        }
    }
}