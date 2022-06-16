using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Service.Interfeces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CollectionManagementAPI.Service.Service;

public class IdentityService : IIdentityService
{
    private readonly string PasswordSalt = "uevJ8F0GpIlP1oagdo0FLokQ7zDuLpHa";

    public void CreatePasswordHash(string password, out byte[] passwordHash)
    {
        using (var hmac = new HMACSHA512(System.Text.Encoding.UTF8.GetBytes(PasswordSalt)))
        {
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash)
    {
        using (var hmac = new HMACSHA512(System.Text.Encoding.UTF8.GetBytes(PasswordSalt)))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    public string CreateToken(UserEntity user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        
        var token = new JwtSecurityToken(
            claims: claims,    
            expires: DateTime.Now.AddDays(AuthorizationOption.Expires),
            signingCredentials: AuthorizationOption.Credentials,
            audience: AuthorizationOption.Audience,
            issuer: AuthorizationOption.Issuer

        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}