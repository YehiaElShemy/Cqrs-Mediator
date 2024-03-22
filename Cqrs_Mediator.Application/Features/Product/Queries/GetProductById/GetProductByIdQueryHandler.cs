using AutoMapper;
using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator.Application.Abstractions.RepositoryContract;
using Cqrs_Mediator_Domain.Entities;
using MediatR;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDto>
    {
        private readonly IDbConnectionFactory<Products> _factory;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IDbConnectionFactory<Products> factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }
        public async Task<GetProductByIdDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           /* var result = _unitOfWork._product.GetByIdAsync(request.Id);
            return _mapper.Map<GetProductByIdDto>(result);
           */
           var result= await _factory.QueryFirstOrDefaultAsync("getproductbyid", request,null,cancellationToken);
            if (result == null)
            {
                return new GetProductByIdDto();
            }
           /* var product = result.FirstOrDefault();*/
            return _mapper.Map<GetProductByIdDto>(result);
        }
    }
}
