using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyStore.Api;
using MyStore.Services.Products.Dto;
using Newtonsoft.Json;
using Xunit;

namespace MyStore.Tests.EndToEnd.Controllers
{
    public class ProductsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProductsControllerTests()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Fact]
        public async Task get_should_return_products()
        {
            var response = await _client.GetAsync("/products");

            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().BeTrue();

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert
                .DeserializeObject<IEnumerable<ProductDto>>(content);

            products.Should().NotBeEmpty();
        }
    }
}