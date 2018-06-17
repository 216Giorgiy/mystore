using Newtonsoft.Json;

namespace MyStore.Services.Users.Commands
{
    public class SignIn
    {
        public string Username { get; }
        public string Password { get; }
        
        [JsonConstructor]
        public SignIn(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}