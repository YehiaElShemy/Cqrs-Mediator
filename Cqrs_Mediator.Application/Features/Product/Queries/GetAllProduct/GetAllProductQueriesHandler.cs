using AutoMapper;
using Cqrs_Mediator.Application.Abstractions;
using MediatR;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct
{
    public class GetAllProductQueriesHandler : IRequestHandler<GetProductQueries, IEnumerable<ProductDto>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductQueriesHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductQueries request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork._product.GetAllIncludes();//GetAllProductPagaintion(request.page,request.pageSize);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
           

        }
    }
}
