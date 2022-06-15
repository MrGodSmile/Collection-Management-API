using CollectionManagementAPI.Entity;

namespace CollectionManagementAPI.Service.Interfeces;

public interface IIdentityService
{
    void CreatePasswordHash(string password, out byte[] passwordHash);
    bool VerifyPasswordHash(string password, byte[] passwordHash);
    string CreateToken(UserEntity user);
}