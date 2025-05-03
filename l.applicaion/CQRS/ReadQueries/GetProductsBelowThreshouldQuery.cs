using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS
{
    public record GetProductsBelowThresholdQuery() : IRequest<IEnumerable<ProductDto>>;

    public class GetProductsBelowThresholdHandler : IRequestHandler<GetProductsBelowThresholdQuery, IEnumerable<ProductDto>>
    {
        private readonly IReportService _reportService;

        public GetProductsBelowThresholdHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsBelowThresholdQuery request, CancellationToken cancellationToken)
        {
            return (IEnumerable<ProductDto>)await _reportService.GetProductsBelowThreshould();
        }
    }
}
