using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct
{
    public sealed record GetProductQueries() : IRequest<IEnumerable<ProductDto>>;

}
