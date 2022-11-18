using System.Security.Claims;
using JWTDemo.Models.Response;
using System.IdentityModel.Tokens.Jwt;

namespace JWTDemo.Services
{
    public interface IJWTService
    {
        TokenResultModel GenerateTokens(string username, Claim[] claims, DateTime now);

        TokenResultModel RefreshToken(string refreshToken, string accessToken, DateTime now);

        (ClaimsPrincipal, JwtSecurityToken) DecodeToken(string token);
    }
}

