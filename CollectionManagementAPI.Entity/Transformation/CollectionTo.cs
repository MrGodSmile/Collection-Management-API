using CollectionManagementAPI.Entity.Models.Collections;

namespace CollectionManagementAPI.Entity.Transformation;

public static class CollectionTo
{
    public static CollectionModel ToCollectionModel(this CollectionEntity collectionEntity)
    {
        return new CollectionModel()
        {
            Id = collectionEntity.Id,
            Name = collectionEntity.Name,
            Description = collectionEntity.Description,
            Topic = collectionEntity.Topic
        };
    }
}