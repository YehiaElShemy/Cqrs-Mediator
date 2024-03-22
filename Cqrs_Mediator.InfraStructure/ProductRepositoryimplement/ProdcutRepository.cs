using Cqrs_Mediator.Application.Abstractions.ProductContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using Cqrs_Mediator_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cqrs_Mediator.InfraStructure.Repositoryimplement
{
    public class ProdcutRepository : AsyncRepository<Products>, IRepositoryProduct
    {
        public ProdcutRepository(ApplicationContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Products>> GetAllProductPagaintion(int page,int pageSize)
        {
            return await db.Set<Products>()
                .OrderBy(a=>a.Id)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
