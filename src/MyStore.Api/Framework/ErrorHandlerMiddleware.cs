using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyStore.Api.Framework
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Incoming request.");
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error: {ex.Message}");
                await HandleErrorAsync(context, ex);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var payload = new { message = exception.Message, code = "error" };
            var json = JsonConvert.SerializeObject(payload);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(json);
        }
    }
}