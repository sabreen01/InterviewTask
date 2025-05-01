using l.applicaion.CQRS;
using l.applicaion.CQRS.WriteCommands;
using l.applicaion.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddStock")]
        public async Task<IActionResult> AddStock([FromBody] StockTransactionDto transactionDto)
        {
            await _mediator.Send(new AddStockCommand(transactionDto));
            return Ok();
        }

        [HttpPost("RemoveStock")]
        public async Task<IActionResult> RemoveStock([FromBody] StockTransactionDto transactionDto)
        {
            await _mediator.Send(new RemoveStockCommand(transactionDto));
            return Ok();
        }

        [HttpPost("TransferStock")]
        public async Task<IActionResult> TransferStock([FromBody] StockTransferDto transactionDto)
        {
            await _mediator.Send(new StockTransferCommand(transactionDto));
            return Ok();
        }
    }
}
