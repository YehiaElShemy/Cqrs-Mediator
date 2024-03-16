using Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdDto>
    {
        public int Id { get; set; }
    }
}
