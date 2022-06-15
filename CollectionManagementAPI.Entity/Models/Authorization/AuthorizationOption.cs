using Microsoft.IdentityModel.Tokens;

namespace CollectionManagementAPI.Entity;

public class AuthorizationOption
{
    public const string Issuer = "CollectionsManagementAPIServer";
    public const string Audience = "CollectionsManagementAPIClient";
    public const string Token = "aK6VwdPhri8hrVCZVXRabI17ywvhAbaV";
    public const int Expires = 1;
    
    private static SymmetricSecurityKey key = new SymmetricSecurityKey(
        System.Text.Encoding.UTF8.GetBytes(AuthorizationOption.Token));

    public static SigningCredentials Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
}