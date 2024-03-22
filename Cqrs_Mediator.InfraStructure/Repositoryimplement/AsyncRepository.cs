using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator.Application.Abstractions.RepositoryContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data;
using System.Linq.Expressions;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs_Mediator.InfraStructure.Repositoryimplement
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationContext db;


        private readonly DbSet<T> dbSet;

        public AsyncRepository(ApplicationContext _db)
        {
            db = _db;
            dbSet = db.Set<T>();
        }


 
        public async Task<T> CreateAsync(T entity) =>
               (await dbSet.AddAsync(entity)).Entity;


        public void CreateRangeAsync(IEnumerable<T> entities)
        {
            dbSet.AddRangeAsync(entities);
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            var result = await Task.FromResult(dbSet.Remove(entity));
            return result is not null ? true : false;
        }
        public IEnumerable<T> GetAllIncludes(params Expression<Func<T, Object>>[] includes)
        {
            var entities = dbSet.AsQueryable();
            foreach (var include in includes)
            {
                return entities.Include(include);
            }
            return entities.ToList();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression) =>
            await dbSet.Where(expression).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync() =>
             await dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(object id) =>
             await dbSet.FindAsync(id);


        public void RemoveRangeAsync(IEnumerable<T> entities) =>
            dbSet.RemoveRange(entities);


        public async Task<T> UpdateAsync(T entity) =>
            await Task.FromResult(dbSet.Update(entity).Entity);

     
        /*        dbSet.Attach(entity);
db.Entry(entity).State = EntityState.Modified;
return entity;*/


    }
}
