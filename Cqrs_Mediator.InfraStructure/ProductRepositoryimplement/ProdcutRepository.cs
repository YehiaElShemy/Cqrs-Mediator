using Cqrs_Mediator.Application.Contract.ProductContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using Cqrs_Mediator_Domain.Entities;

namespace Cqrs_Mediator.InfraStructure.Repositoryimplement
{
    public class ProdcutRepository : AsyncRepository<Products>, IRepositoryProduct
    {
        public ProdcutRepository(ApplicationContext db) : base(db)
        {
        }

        Task<IEnumerable<Products>> IRepositoryProduct.GetPopularProjects(int count)
        {
            throw new NotImplementedException();
        }
    }
}
