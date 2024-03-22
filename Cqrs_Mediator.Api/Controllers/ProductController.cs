using Cqrs_Mediator.Application.Features.Product.Commands.CreateProduct;
using Cqrs_Mediator.Application.Features.Product.Commands.DeleteProduct;
using Cqrs_Mediator.Application.Features.Product.Commands.UpdateProduct;
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
            return Ok(await _mediator.Send(new GetProductQueries(1,2)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery() { id=id}));
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(AddProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(command));
        }
        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(command));
        }
    }
}
