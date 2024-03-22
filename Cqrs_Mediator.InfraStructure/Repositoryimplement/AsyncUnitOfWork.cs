using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator.Application.Abstractions.ProductContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;


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
        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return await db.SaveChangesAsync(cancellationToken);
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction=db.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }
    }
}
