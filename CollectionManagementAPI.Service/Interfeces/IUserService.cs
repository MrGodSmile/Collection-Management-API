using CollectionManagementAPI.Entity;

namespace CollectionManagementAPI.Service.Interfeces;

public interface IUserService
{
    Task<UserEntity> GetById(int id);
    IQueryable<UserEntity> GetAll();
    IQueryable<UserEntity> GetRange(int skip, int take);
    Task Create(UserEntity user);
    Task Update(UserEntity user);
    Task<bool> Delete(int id);
    UserEntity SearchByLogin(string login);
}