using AutoMapper;
using Cqrs_Mediator.Application.Abstractions;
using MediatR;
using Cqrs_Mediator_Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Cqrs_Mediator.Application.Features.Product.Commands.CreateProduct
{
    internal class AddProductHandler : IRequestHandler<AddProductCommand, ProductDto>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddProductHandler> _logger;
     

        public AddProductHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper, ILogger<AddProductHandler> logger )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
          
        }
        public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            using var transaction=_unitOfWork.BeginTransaction();
            try
            {
                //var res = _dbContext.Products.Add(request);
                    
                var productToCreate = _mapper.Map<Products>(request);
                var createProduct =await _unitOfWork._product.CreateAsync(productToCreate);
                var result = await _unitOfWork.SaveChangeAsync(cancellationToken);
                if (result > 0)
                {
                    transaction.Commit();
                    ProductDto productDto = _mapper.Map<ProductDto>(createProduct);
                    return productDto;
                }
                else
                {
                    
                    _logger.LogWarning("No changes were made during the Add operation.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                /*_logger.LogError(ex, "An error occurred while Add the product.");*/
                throw; 
            }
        }
    }
}
