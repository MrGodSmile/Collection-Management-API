namespace CollectionManagementAPI.Entity;

public class UserEntity
{
    
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public string Email { get; set; }

    public byte[]? PasswordHash { get; set; }

    public string? Name { get; set; }
    
    public string? Surname { get; set; }

}