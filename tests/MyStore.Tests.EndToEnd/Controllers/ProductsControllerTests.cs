using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyStore.Api;

namespace MyStore.Tests.EndToEnd.Controllers
{
    public class ProductsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProductsControllerTests()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("test"));

            _client = _server.CreateClient();
        }
    }
}