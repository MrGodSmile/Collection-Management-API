using System.Collections.ObjectModel;
using CollectionManagementAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagementAPI.DataAccess;

public class CollectionManagementDbContext : DbContext
{
    public CollectionManagementDbContext(DbContextOptions<CollectionManagementDbContext> options) :
        base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Role)
            .HasConversion<string>();
        modelBuilder.Entity<CollectionEntity>()
            .HasOne(c => c.User)
            .WithMany(u => u.Collections)
            .HasForeignKey(c => c.UserId);
    }
    
    
    public DbSet<CollectionEntity> Collections { get; set; }
    
    public DbSet<ElementEntity> Elements { get; set; }
    
    public DbSet<TagEntity> Tags { get; set; }
    
    public DbSet<UserEntity> Users { get; set; }
}