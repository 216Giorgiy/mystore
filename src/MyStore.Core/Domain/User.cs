using System;

namespace MyStore.Core.Domain
{
    public class User : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        private User()
        {
        }

        public User(string username, string role)
        {
            Username = username;
            Role = role;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Invalid password.",
                    nameof(password));
            }

            Password = password;
        }
    }
}