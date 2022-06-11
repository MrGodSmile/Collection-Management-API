namespace CollectionManagementAPI.Entity;

public class TagEntity
{
    
    public int Id { get; set; }
    
    public string Name { get; set; }

    public int ElementEntityId { get; set; }
    
    public ElementEntity? ElementEntity { get; set; }
    
}