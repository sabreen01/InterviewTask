
using domain.Filters;
using l.applicaion.CQRS;
using l.applicaion.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetTransactionsReport")]
        public async Task<IActionResult> GetTransactionsReport([FromQuery] TransactionHistoryReportFilter filter)
        {
            var transactions = await _reportService.GetTransactionsReport(filter);
            return Ok(transactions);
        }


        [HttpGet("GetProductsBelowThreshould")]
        public async Task<IActionResult> GetProductsBelowThreshould()
        {
            var products = await _reportService.GetProductsBelowThreshould();
            return Ok(products);
        }
    }
}
