using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using MyStore.Core.Domain;
using MyStore.Infrastructure.Auth;
using MyStore.Services.Users;
using MyStore.Services.Users.Commands;
using Xunit;

namespace MyStore.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public void sign_in_should_fail_for_invalid_credentials()
        {
            //Arrange
            var command = new SignIn("user", "secret");
            var jwtProviderMock = new Mock<IJwtProvider>();
            var passwordHasherMock = new Mock<IPasswordHasher<User>>();
            
            passwordHasherMock.Setup(x => x.VerifyHashedPassword(It.IsAny<User>(),
                    It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Failed);

            var userService = new UserService(jwtProviderMock.Object,
                passwordHasherMock.Object);

            //Act
            Func<Task<JsonWebToken>> signIn = () => userService.SignInAsync(command);
            
            //Assert
            var result = signIn.Should().Throw<Exception>();
            result.And.Message.Should().BeEquivalentTo("Invalid credentials.");
            
            passwordHasherMock.Verify(x => x.VerifyHashedPassword(It.IsAny<User>(),
                It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}