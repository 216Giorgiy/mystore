using Newtonsoft.Json;

namespace MyStore.Services.Users.Commands
{
    public class SignUp
    {        
        public string Username { get; }
        public string Password { get; }
        public string Role { get; }
        
        [JsonConstructor]
        public SignUp(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}