using Cqrs_Mediator.Application.Abstractions.ProductContract;
using System.Data;

namespace Cqrs_Mediator.Application.Abstractions
{
    public interface IAsyncUnitOfWork:IDisposable
    {
        //add anthor of reference property
        public IRepositoryProduct _product { get; set; }
        public IRepositoryCategory _Category { get; set; }
        Task<int> SaveChangeAsync(CancellationToken cancellationToken=default);
        IDbTransaction BeginTransaction();
    }
}
