using l.applicaion.CQRS;
using l.applicaion.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllWarehouseQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WarehouseDto stock)
        {
            await _mediator.Send(new CreateWarehouseCommand(stock));
            return Ok();
        }
    }
}
