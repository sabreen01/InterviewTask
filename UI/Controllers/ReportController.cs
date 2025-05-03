using domain.Filters;
using l.applicaion.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTransactionsReport")]
        public async Task<IActionResult> GetTransactionsReport([FromQuery] TransactionHistoryReportFilter filter)
        {
            var result = await _mediator.Send(new GetTransactionsReportQuery(filter));
            return Ok(result);
        }

        [HttpGet("GetProductsBelowThreshold")]
        public async Task<IActionResult> GetProductsBelowThreshold()
        {
            var result = await _mediator.Send(new GetProductsBelowThresholdQuery());
            return Ok(result);
        }
    }
}
