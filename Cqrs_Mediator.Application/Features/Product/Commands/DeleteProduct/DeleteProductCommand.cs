using Cqrs_Mediator_Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cate_id { get; set; }
    }
}
