using CollectionManagementAPI.DataAccess.Interfeces;
using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Service.Interfeces;
using Microsoft.EntityFrameworkCore;


namespace CollectionManagementAPI.Service.Service;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _userRepository;
    
    public UserService(IRepository<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserEntity> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        return user;
    }
    
    public async Task Create(UserEntity user)
    {
        await _userRepository.Create(user);
    }

    public async Task Update(UserEntity user)
    {
        await _userRepository.Update(user);
    }

    public async Task<bool> Delete(int id)
    {
        bool result = await _userRepository.Delete(id);
        return result;
    }

    public async Task<UserEntity> SearchByLogin(string login)
    {
        var user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == login);
        return user;
    }
}