using Cqrs_Mediator.Application.Contract.ProductContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using DomainLayer.Contract;

namespace Cqrs_Mediator.InfraStructure.Repositoryimplement
{
    public class AsyncUnitOfWork : IAsyncUnitOfWork
    {

        public ApplicationContext db { get; set; }
        public IRepositoryProduct _product { get; set; }
        public IRepositoryCategory _Category { get; set; }
        public AsyncUnitOfWork(ApplicationContext _db)
        {
            db = _db;
            _product = new ProdcutRepository(db);
          
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<int> SaveChangeAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
