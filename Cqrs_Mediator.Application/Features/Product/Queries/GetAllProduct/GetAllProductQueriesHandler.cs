using DomainLayer.Contract;
using MediatR;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct
{
    public class GetAllProductQueriesHandler : IRequestHandler<GetProductQueries, IEnumerable<GetAllProductListDto>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;

        public GetAllProductQueriesHandler(IAsyncUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetAllProductListDto>> Handle(GetProductQueries request, CancellationToken cancellationToken)
        {
          var result= _unitOfWork._product.GetAllIncludes();
            return new List<GetAllProductListDto>();

        }
    }
}
