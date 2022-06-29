using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Entity.Models.Collections;
using Microsoft.VisualBasic;

namespace CollectionManagementAPI.Service.Interfeces;

public interface ICollectionService
{
    IQueryable<CollectionEntity> GetAll();
    IQueryable<CollectionEntity> GetRange(int skip, int take);
    Task<CollectionEntity> GetById(int id);
    Task Create(CollectionEntity collection);
    Task Update(CollectionEntity collection, CollectionModel updateModel);
    Task<bool> Delete(int id);
    Task<CollectionEntity> SearchByName(string name);
}