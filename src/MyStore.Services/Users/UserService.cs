using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyStore.Core.Domain;
using MyStore.Infrastructure.Auth;
using MyStore.Services.Users.Commands;

namespace MyStore.Services.Users
{
    public class UserService : IUserService
    {
        private static readonly List<User> _users = new List<User>
        {
            new User("user", "user")
        };
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IJwtProvider jwtProvider,
            IPasswordHasher<User> passwordHasher)
        {
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<JsonWebToken> SignInAsync(SignIn command)
        {
            var user = _users.SingleOrDefault(x => x.Username == command.Username);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }

            var passwordResult = _passwordHasher.VerifyHashedPassword(user,
                user.Password, command.Password);
            if (passwordResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid credentials.");
            }

            await Task.CompletedTask;

            return _jwtProvider.Create(user.Id, user.Role);
        }

        public async Task SignUpAsync(SignUp command)
        {
            var user = _users.SingleOrDefault(x => x.Username == command.Username);
            if (user != null)
            {
                throw new Exception("Username is in use.");
            }
            user = new User(command.Username, command.Role ?? "user");
            var passwordHash = _passwordHasher.HashPassword(user, command.Password);
            user.SetPassword(passwordHash);
            _users.Add(user);
            await Task.CompletedTask;
        }
    }
}