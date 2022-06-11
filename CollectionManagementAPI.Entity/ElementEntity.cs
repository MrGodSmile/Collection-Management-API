namespace CollectionManagementAPI.Entity;

public class ElementEntity
{
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Tag { get; set; }
    
    public string Comment { get; set; }

    public List<TagsEntity> Tags { get; set; } = new();

}