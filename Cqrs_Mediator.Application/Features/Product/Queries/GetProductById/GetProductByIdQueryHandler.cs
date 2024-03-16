using AutoMapper;
using Cqrs_Mediator.Application.Contract;
using MediatR;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDto>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetProductByIdDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork._product.GetByIdAsync(request.Id);
            return _mapper.Map<GetProductByIdDto>(result);
           

        }
    }
}
