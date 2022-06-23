namespace CollectionManagementAPI.Entity;

public class ElementEntity
{
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Tag { get; set; }
    
    public string Comment { get; set; }

    public ICollection<TagEntity> Tags { get; set; }
    public CollectionEntity Collection { get; set; }

}