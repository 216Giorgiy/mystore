using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MyStore.Api.Framework
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string policy = null)
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
            Policy = policy;
        }
    }
}