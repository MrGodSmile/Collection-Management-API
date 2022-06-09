using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class Context : DbContext
{
   public Context(DbContextOptions<Context> options) :
       base(options)
   {
        
   }   
   public DbSet<Example> Examples { get; set; }
}