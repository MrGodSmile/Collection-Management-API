using CollectionManagementAPI.DataAccess.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagementAPI.DataAccess.Service;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> db;
    
    private readonly CollectionManagementDbContext _context;

    public Repository(CollectionManagementDbContext context)
    {
        _context = context;
        db = _context.Set<T>();
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return await db.AsNoTracking<T>().ToListAsync() as IQueryable<T>; 
    }

    public async Task<T> GetById(int id)
    {
        return await db.FindAsync(id);
    }

    public async Task Create(T item)
    {
        await db.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T item)   
    {
        db.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        T collection = await db.FindAsync(id);
        if (id != null)
        {
            db.Remove(collection);
            return true;
        }

        return false;
    }
}
