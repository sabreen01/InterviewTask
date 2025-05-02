using domain.Models;
using l.applicaion.CQRS;
using l.applicaion.CQRS.WriteCommands;
using l.applicaion.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product is not null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto product)
        {
            await _mediator.Send(new CreateProductCommand(product));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return  Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductDto product)
        {
            await _mediator.Send(new UpdateProductCommand(product));
            return Ok();
        }
        // Add Update and Delete similarly...
    }

}
