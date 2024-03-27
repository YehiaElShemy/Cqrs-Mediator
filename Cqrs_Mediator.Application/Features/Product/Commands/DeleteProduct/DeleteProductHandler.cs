using AutoMapper;
using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator_Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DelegatingHandler> _logger;

        public DeleteProductHandler(IAsyncUnitOfWork unitOfWork, IMapper mapper, ILogger<DelegatingHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productToDelete = _mapper.Map<Products>(request);
                var DeleteProduct = await _unitOfWork._product.DeleteAsync(productToDelete);
                var res = await _unitOfWork.SaveChangeAsync(cancellationToken);
                if (res > 0)
                {
                    return _mapper.Map<ProductDto>(DeleteProduct);

                }
                {
                    // Handle the case where no changes were made or persisted
                    // For example:
                    _logger.LogWarning("No changes were made during the update operation.");
                    return null; // Or throw an exception, depending on your requirements
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle it accordingly
                _logger.LogError(ex, "An error occurred while updating the product.");
                throw; // Rethrow the exception to propagate it to the caller
            }

        }
    }
}
