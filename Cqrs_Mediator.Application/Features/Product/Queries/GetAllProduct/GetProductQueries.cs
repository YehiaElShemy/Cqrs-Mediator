using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct
{
    public class GetProductQueries : IRequest<IEnumerable<GetAllProductListDto>>
    {
       
    }
}
