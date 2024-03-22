using Cqrs_Mediator.Application.Abstractions.RepositoryContract;
using Cqrs_Mediator_Domain.Entities;
namespace Cqrs_Mediator.Application.Abstractions.ProductContract
{
    public interface IRepositoryProduct : IAsyncRepository<Products>
    {
        Task<IEnumerable<Products>> GetAllProductPagaintion(int page, int pageSize);
    }
}
