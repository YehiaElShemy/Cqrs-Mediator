
using Cqrs_Mediator_Domain.Entities;
using DomainLayer.Contract;


namespace Cqrs_Mediator.Application.Contract.ProductContract
{
    public interface IRepositoryCategory : IAsyncRepository<Category>
    {
        Task<IEnumerable<Category>> GetPopularProjects(int count);
    }
}
