using CollectionManagementAPI.DataAccess.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagementAPI.DataAccess.Service;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CollectionManagementDbContext _context;

    public Repository(CollectionManagementDbContext context) => _context = context;
    
    public async Task<IEnumerable<T>> GetList()
    {
        return await _context.Set<T>().ToListAsync() as IEnumerable<T>;
    }

    public async Task<T> Get(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Create(T item)
    {
        await _context.Set<T>().AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T item)   
    {
        _context.Set<T>().Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        T collection = await _context.Set<T>().FindAsync(id);
        if (id != null)
            _context.Set<T>().Remove(collection);
    }
}
