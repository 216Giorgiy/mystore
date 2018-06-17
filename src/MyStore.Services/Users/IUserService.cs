using System.Threading.Tasks;
using MyStore.Infrastructure.Auth;
using MyStore.Services.Users.Commands;

namespace MyStore.Services.Users
{
    public interface IUserService
    {
        Task<JsonWebToken> SignInAsync(SignIn command);
        Task SignUpAsync(SignUp command);
    }
}