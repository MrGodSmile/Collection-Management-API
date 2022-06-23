using CollectionManagementAPI.DataAccess.Interfeces;
using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Service.Interfeces;

namespace CollectionManagementAPI.Service.Service;

public class CollectionService : ICollectionService
{
    private readonly IRepository<CollectionEntity> _collectionRepository;
    
    public CollectionService(IRepository<CollectionEntity> collectionRepository)
    {
        _collectionRepository = collectionRepository;
    }
    
    public IQueryable<CollectionEntity> GetAll()
    {
        return _collectionRepository.GetAll();
    }

    public IQueryable<CollectionEntity> GetPeriod(int skip, int take)
    {
        var period = _collectionRepository.GetAll().Skip(skip).Take(take);
        return period;
    }


    public async Task<CollectionEntity> GetById(int id)
    {
        var collection = await _collectionRepository.GetById(id);
        return collection;
    }

    public async Task Create(CollectionEntity collection)
    {
        await _collectionRepository.Create(collection);
    }

    public async Task Update(CollectionEntity collection)
    {
        await _collectionRepository.Update(collection);
    }

    public async Task<bool> Delete(int id)
    {
        bool result = await _collectionRepository.Delete(id);
        return result;
    }

    public async Task<CollectionEntity> SearchByName(string name)
    {
        var collection = _collectionRepository.GetAll().FirstOrDefault(u => u.Name == name);
        return collection;
    }
}