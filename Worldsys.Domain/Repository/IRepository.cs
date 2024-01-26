namespace Worldsys.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<dynamic> ExecuteFromStoredProcedure(string storedProcedureName, object[] parameters);
    }
}
