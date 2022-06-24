using CollectionManagementAPI.DataAccess.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagementAPI.DataAccess.Service;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> dbSet;
    
    private readonly CollectionManagementDbContext _context;

    public Repository(CollectionManagementDbContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return dbSet.AsNoTracking();
    }

    public async Task<T> GetById(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task Create(T item)
    {
        await dbSet.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T item)   
    {
        dbSet.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        T item = await dbSet.FindAsync(id);
        if (item != null)
        {
            dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
