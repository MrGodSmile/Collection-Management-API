namespace CollectionManagementAPI.Entity;

public class CollectionEntity
{
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int UserId { get; set; }
    
    public string Topic { get; set; }
    public ICollection<ElementEntity> Elements { get; set; }
    public UserEntity User { get; set; }
    
}