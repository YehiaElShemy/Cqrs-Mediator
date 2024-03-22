using AutoMapper;
using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator_Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Cqrs_Mediator.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductDto>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductHandler> _logger;
        public UpdateProductHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UpdateProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productToUpdate = _mapper.Map<Products>(request);
                var updatedProduct = await _unitOfWork._product.UpdateAsync(productToUpdate);
                var result = await _unitOfWork.SaveChangeAsync(cancellationToken);

                if (result > 0)
                {
                    var productDto = _mapper.Map<UpdateProductDto>(updatedProduct);
                    return productDto;
                }
                else
                {

                    _logger.LogWarning("No changes were made during the update operation.");
                    return null;
                }
            }
            catch (Exception ex)
            {
               
                _logger.LogError(ex, "An error occurred while updating the product.");
                throw; 
            }
        }
    }
}
