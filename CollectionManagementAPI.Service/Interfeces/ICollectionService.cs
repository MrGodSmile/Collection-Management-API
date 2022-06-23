using CollectionManagementAPI.Entity;
using Microsoft.VisualBasic;

namespace CollectionManagementAPI.Service.Interfeces;

public interface ICollectionService
{
    IQueryable<CollectionEntity> GetAll();

    IQueryable<CollectionEntity> GetPeriod(int skip, int take);
    Task<CollectionEntity> GetById(int id);
    Task Create(CollectionEntity collection);
    Task Update(CollectionEntity collection);
    Task<bool> Delete(int id);
    Task<CollectionEntity> SearchByName(string name);
}