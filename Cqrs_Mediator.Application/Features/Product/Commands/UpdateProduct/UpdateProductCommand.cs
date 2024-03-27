using MediatR;
namespace Cqrs_Mediator.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cate_id { get; set; }
    }
}
