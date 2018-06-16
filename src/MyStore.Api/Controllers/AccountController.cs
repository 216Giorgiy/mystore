using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Infrastructure.Auth;

namespace MyStore.Api.Controllers
{
    [Route("")]
    public class AccountController : BaseController
    {
        private readonly IJwtProvider _jwtProvider;

        public AccountController(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }
        
        [HttpGet("me")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<string> Get() => User.Identity.Name;

        [HttpPost("sign-in")]
        public ActionResult<JsonWebToken> SignIn()
            => _jwtProvider.Create(Guid.NewGuid(), "user");
    }
}