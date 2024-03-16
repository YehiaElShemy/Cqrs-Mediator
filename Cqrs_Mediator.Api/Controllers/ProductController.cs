using Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct;
using Cqrs_Mediator.Application.Features.Product.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs_Mediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _mediator.Send(new GetProductQueries()));
        }
        [HttpGet()]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery() { Id=id}));
        }
    }
}
