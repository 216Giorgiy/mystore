using System;

namespace MyStore.Infrastructure.Auth
{
    public interface IJwtProvider
    {
        JsonWebToken Create(Guid userId, string role);
    }
    
    //Microsoft.IdentityModel.Tokens
    //System.IdentityModel.Tokens.Jwt
    
    //bit.ly/sii-jwt
}