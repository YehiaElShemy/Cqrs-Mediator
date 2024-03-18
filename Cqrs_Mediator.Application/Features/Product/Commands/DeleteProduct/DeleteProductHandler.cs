using AutoMapper;
using Cqrs_Mediator.Application.Contract;
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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
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
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _mapper.Map<Products>(request);
                var productDelete = await _unitOfWork._product.DeleteAsync(result);
                var res = await _unitOfWork.SaveChangeAsync();
                if (res > 0)
                {
                    return productDelete;
                }
                {
                    // Handle the case where no changes were made or persisted
                    // For example:
                    _logger.LogWarning("No changes were made during the update operation.");
                    return false; // Or throw an exception, depending on your requirements
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
