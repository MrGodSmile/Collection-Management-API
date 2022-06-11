namespace CollectionManagementAPI.DataAccess.Interfeces;

interface IRepository<T> where T : class
{
    Task<IQueryable<T>> GetAll();
    Task<T> Get(int id);
    Task Create(T item);
    Task Update(T item);
    Task Delete(int id);

}