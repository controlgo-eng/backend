using Microsoft.EntityFrameworkCore;
using Worldsys.Domain.Repository;

namespace Worldsys.Infrastructure.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public EntityFrameworkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<dynamic> ExecuteFromStoredProcedure(string storedProcedureName, object[] parameters)
        {
            var sqlCommand = $"EXEC {storedProcedureName}";
            return await _context.Set<T>().FromSqlRaw(sqlCommand, parameters).ToListAsync();
        }
    }
}
