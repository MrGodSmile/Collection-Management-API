namespace CollectionManagementAPI.DataAccess.Interfeces;

interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T> GetById(int id);
    Task Create(T item);
    Task Update(T item);
    Task<bool> Delete(int id);

}