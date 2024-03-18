using Cqrs_Mediator_Domain.Entities;
namespace Cqrs_Mediator.Application.Contract.ProductContract
{
    public interface IRepositoryProduct : IAsyncRepository<Products>
    {
        Task<IEnumerable<Products>> GetPopularProjects(int count);
    }
}
