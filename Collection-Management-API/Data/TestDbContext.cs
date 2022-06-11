using Collection_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Collection_Management_API.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) :
        base(options)
    {
        
    }
    
    public DbSet<Test> Tests { get; set; }
}