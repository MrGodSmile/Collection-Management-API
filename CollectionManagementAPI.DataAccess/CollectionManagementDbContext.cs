using System.Collections.ObjectModel;
using CollectionManagementAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagementAPI.DataAccess;

public class CollectionManagementDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }
    public CollectionManagementDbContext(DbContextOptions<CollectionManagementDbContext> options) :
        base(options)
    {
        
    }
    
    public DbSet<CollectionEntity> Collections { get; set; }
    
    public DbSet<ElementEntity> Elements { get; set; }
    
    public DbSet<TagEntity> Tags { get; set; }
    
    public DbSet<UserEntity> Users { get; set; }
}