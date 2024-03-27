using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Features.Product.Commands.CreateProduct
{
    public class AddProductCommand:IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cate_id { get; set; }

    }
}
