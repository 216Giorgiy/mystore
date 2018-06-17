using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Api.Framework;
using MyStore.Infrastructure.Auth;
using MyStore.Services.Users;
using MyStore.Services.Users.Commands;

namespace MyStore.Api.Controllers
{
    [Route("")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("me")]
        [Auth]
        public ActionResult<string> Get() => User.Identity.Name;

        [HttpPost("sign-in")]
        public async Task<ActionResult<JsonWebToken>> SignIn([FromBody] SignIn command)
            => Ok(await _userService.SignInAsync(command));

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp([FromBody] SignUp command)
        {
            await _userService.SignUpAsync(command);

            return Created(nameof(Get), null);
        }
    }
}