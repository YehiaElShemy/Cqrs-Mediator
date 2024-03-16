using Cqrs_Mediator_Domain.Entities;
namespace Cqrs_Mediator.Application.Contract.ProductContract
{
    public interface IRepositoryProduct : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetPopularProjects(int count);
    }
}
