using domain.Models;
using l.applicaion.CQRS;
using l.applicaion.CQRS.WriteCommands;
using l.applicaion.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        [HttpPost("AddStock")]
        public async Task<IActionResult> AddStock([FromBody] StockTransactionDto transactionDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _mediator.Send(new AddStockCommand(transactionDto, userId));
            return Ok();
        }

        [Authorize]
        [HttpPost("RemoveStock")]
        public async Task<IActionResult> RemoveStock([FromBody] StockTransactionDto transactionDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _mediator.Send(new RemoveStockCommand(transactionDto, userId));
            return Ok();
        }

        [Authorize]
        [HttpPost("TransferStock")]
        public async Task<IActionResult> TransferStock([FromBody] StockTransferDto transactionDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _mediator.Send(new StockTransferCommand(transactionDto, userId));
            return Ok();
        }
    }
}
