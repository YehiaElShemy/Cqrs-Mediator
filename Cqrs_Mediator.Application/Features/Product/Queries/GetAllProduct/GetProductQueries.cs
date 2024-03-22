using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct
{
    public sealed record GetProductQueries(int page, int pageSize) : IRequest<IEnumerable<GetAllProductListDto>>;

}
