using CollectionManagementAPI.Entity;

namespace CollectionManagementAPI.Service.Interfeces;

public interface IUserService
{
    Task<UserEntity> GetById(int id);
    Task Create(UserEntity user);
    Task Update(UserEntity user);
    Task<bool> Delete(int id);
    Task<UserEntity> SearchByLogin(string login);
}