using AutoMapper;
using Cqrs_Mediator.Application.Contract;
using MediatR;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct
{
    public class GetAllProductQueriesHandler : IRequestHandler<GetProductQueries, IEnumerable<GetAllProductListDto>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductQueriesHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllProductListDto>> Handle(GetProductQueries request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork._product.GetAllIncludes();
            return _mapper.Map<IEnumerable<GetAllProductListDto>>(result);
           

        }
    }
}
