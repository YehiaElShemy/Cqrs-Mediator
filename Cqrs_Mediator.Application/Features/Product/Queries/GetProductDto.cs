using Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct;

namespace Cqrs_Mediator.Application.Features.Product.Queries
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto categoryDto { get; set; }
    }
}
