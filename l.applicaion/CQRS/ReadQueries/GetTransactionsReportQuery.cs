using domain.Filters;
using l.applicaion.DTOs;
using l.applicaion.IServices;
using l.application.DTOs;
using MediatR;

namespace l.applicaion.CQRS
{
    public record GetTransactionsReportQuery(TransactionHistoryReportFilter Filter) : IRequest<IEnumerable<TransactionReportDto>>;

    public class GetTransactionsReportHandler : IRequestHandler<GetTransactionsReportQuery, IEnumerable<TransactionReportDto>>
    {
        private readonly IReportService _reportService;

        public GetTransactionsReportHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IEnumerable<TransactionReportDto>> Handle(GetTransactionsReportQuery request, CancellationToken cancellationToken)
        {
            return await _reportService.GetTransactionsReport(request.Filter);
        }
    }
}
