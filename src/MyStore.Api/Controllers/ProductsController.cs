using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MyStore.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Iphone X"),
            new Product(Guid.NewGuid(), "Samsung S8"),
            new Product(Guid.NewGuid(), "Xbox 360")
        };
        private readonly IMemoryCache _cache;

        public ProductsController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] BrowseProducts query)
        {
            query.Name = query.Name ?? string.Empty;

            return Ok(_products.Where(p => p.Name.Contains(query.Name)));
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var product = _cache.Get<Product>(id);
            if (product == null)
            {
                product = _products.SingleOrDefault(x => x.Id == id);
                _cache.Set(id, product);
            }
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id}, null);
        }

        [HttpGet("date")]
        [ResponseCache(Duration = 10, VaryByHeader = "x-custom", 
            VaryByQueryKeys = new []{"time"})]
        public ActionResult<string> GetDate()
        {
            return DateTime.Now.ToString();
        }
    }

    public class BrowseProducts
    {
        public string Name { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set;}
        public string Name { get; private set; }

        private Product()
        {
        }

        public Product(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}